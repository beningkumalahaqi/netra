#!/usr/bin/env bash
set -euo pipefail

echo "Setting up Netra development environment..."

# 1. Install netcoredbg if not present
if ! command -v netcoredbg &> /dev/null && [ ! -f ~/.netcoredbg/netcoredbg ]; then
    echo "Installing netcoredbg (Samsung .NET debugger)..."
    mkdir -p ~/.netcoredbg
    curl -sL "https://github.com/Samsung/netcoredbg/releases/download/3.1.3-1062/netcoredbg-osx-amd64.tar.gz" \
      -o /tmp/netcoredbg.tar.gz
    tar xzf /tmp/netcoredbg.tar.gz -C ~/.netcoredbg --strip-components=1
    rm /tmp/netcoredbg.tar.gz
    echo "Installed to ~/.netcoredbg/netcoredbg"

fi

# 1b. Ensure netcoredbg is registered in Zed
ZED_SETTINGS="$HOME/Library/Application Support/Zed/settings.json"
mkdir -p "$(dirname "$ZED_SETTINGS")"
if [ ! -f "$ZED_SETTINGS" ]; then
    echo '{}' > "$ZED_SETTINGS"
fi
python3 -c "
import json
with open('$ZED_SETTINGS') as f: s = json.load(f)
s.setdefault('dap', {})['netcoredbg'] = s.get('dap', {}).get('netcoredbg', {
    'binary': '$HOME/.netcoredbg/netcoredbg',
    'args': ['--interpreter=vscode']
})
with open('$ZED_SETTINGS', 'w') as f: json.dump(s, f, indent=2)
" 2>/dev/null || echo "⚠️  Could not auto-register netcoredbg in Zed settings"

# 2. Start PostgreSQL
echo "Starting PostgreSQL..."
docker compose up -d postgres

echo "Waiting for PostgreSQL to be healthy..."
until docker compose exec postgres pg_isready -U netra -d netra > /dev/null 2>&1; do
  sleep 1
done

echo "PostgreSQL is ready!"
echo ""
echo "Run the API locally:"
echo "  dotnet run --project src/Netra.Api"
echo ""
echo "Or debug with Zed:"
echo "  Open Debug panel -> select 'Netra.Api (local)' -> F5"
echo ""
echo "Health check: http://localhost:5000/health"
