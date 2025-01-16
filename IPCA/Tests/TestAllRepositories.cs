using System.Collections;
using NUnit.Framework;

namespace IPCA.Tests;

public class TestAllRepositories
{
    [Test]
    public void TestGetAll()
    {
        Assert.IsTrue(RepositoryFactory.GetBuildingRepository().GetAllBuildings().Result.Any());
        Assert.IsTrue(RepositoryFactory.GetClassroomRepository().GetAllClassrooms().Result.Any());
        Assert.IsTrue(RepositoryFactory.GetCourseRepository().GetAllCourses().Result.Any());
        Assert.IsTrue(RepositoryFactory.GetDaysOfWeekRepository().GetAllDaysOfWeek().Result.Any());
        Assert.IsTrue(RepositoryFactory.GetGradeRepository().GetAllGrades().Result.Any());
        Assert.IsTrue(RepositoryFactory.GetPeriodRepository().GetAllPeriods().Result.Any());
        Assert.IsTrue(RepositoryFactory.GetScheduleRepository().GetAllSchedules().Result.Any());
        Assert.IsTrue(RepositoryFactory.GetSchoolRepository().GetAllSchools().Result.Any());
        Assert.IsTrue(RepositoryFactory.GetSubjectRepository().GetAllSubjects().Result.Any());
        Assert.IsTrue(RepositoryFactory.GetTypeUserRepository().GetAllTypesOfUser().Result.Any());
        Assert.IsTrue(RepositoryFactory.GetUserRepository().GetAllUsers().Result.Any());
        Assert.IsTrue(RepositoryFactory.GetUserScheduleRepository().GetAllUserSchedules().Result.Any());
        Assert.IsTrue(RepositoryFactory.GetUserSubjectRepository().GetAllUserSubject().Result.Any());
    }
}