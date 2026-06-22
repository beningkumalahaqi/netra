using Netra.Core.Entities;
using Netra.Core.Enums;
using Netra.Core.Results;

namespace Netra.UnitTests.Core;

public class EntityTests
{
    [Fact]
    public void Entity_WithSameId_AreEqual()
    {
        var id = Guid.NewGuid();
        var p1 = new ProjectEntity { Id = id, Name = "Test" };
        var p2 = new ProjectEntity { Id = id, Name = "Test" };

        Assert.Equal(p1, p2);
    }

    [Fact]
    public void Entity_Constructor_SetsIdAndName()
    {
        var project = new ProjectEntity("My Project");

        Assert.NotEqual(Guid.Empty, project.Id);
        Assert.Equal("My Project", project.Name);
        Assert.Equal("Pending", project.Status);
    }
}

public class ResultTests
{
    [Fact]
    public void SuccessResult_HasValue()
    {
        var result = Result<int>.Success(42);

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(42, result.Value);
    }

    [Fact]
    public void FailureResult_HasError()
    {
        var error = Error.NotFound("Project");
        var result = Result<int>.Failure(error);

        Assert.True(result.IsFailure);
        Assert.Equal("NOT_FOUND", result.Error.Code);
    }

    [Fact]
    public void Match_CallsCorrectBranch()
    {
        var success = Result<int>.Success(10);
        var failure = Result<int>.Failure(Error.Validation("bad"));

        var successResult = success.Match(v => $"value:{v}", e => $"error:{e.Code}");
        var failureResult = failure.Match(v => $"value:{v}", e => $"error:{e.Code}");

        Assert.Equal("value:10", successResult);
        Assert.Equal("error:VALIDATION_ERROR", failureResult);
    }
}

public class EnumTests
{
    [Fact]
    public void ProjectStatus_HasExpectedValues()
    {
        Assert.Equal(0, (int)ProjectStatus.Pending);
        Assert.Equal(1, (int)ProjectStatus.Provisioning);
        Assert.Equal(2, (int)ProjectStatus.Active);
        Assert.Equal(3, (int)ProjectStatus.Failed);
        Assert.Equal(4, (int)ProjectStatus.Archived);
    }
}
