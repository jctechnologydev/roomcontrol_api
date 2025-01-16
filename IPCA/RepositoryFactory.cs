/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
namespace IPCA;

public class RepositoryFactory
{
    #region User Repository
    
    private static IUserRepository _userRepository = null;
    public static IUserRepository GetUserRepository()
    {
        if (_userRepository == null)
            _userRepository = new UserRepository();
        return _userRepository;
    }
    
    #endregion
    
    #region Building Repository
    
    private static IBuildingRepository _buildingRepository = null;
    public static IBuildingRepository GetBuildingRepository()
    {
        if (_buildingRepository == null)
            _buildingRepository = new BuildingRepository();
        return _buildingRepository;
    }
    
    #endregion
    
    #region Classroom Repository
    
    private static IClassroomRepository _classroomRepository = null;
    public static IClassroomRepository GetClassroomRepository()
    {
        if (_classroomRepository == null)
            _classroomRepository = new ClassroomRepository();
        return _classroomRepository;
    }
    
    #endregion
    
    #region Course Repository
    
    private static ICourseRepository _courseRepository = null;
    public static ICourseRepository GetCourseRepository()
    {
        if (_courseRepository == null)
            _courseRepository = new CourseRepository();
        return _courseRepository;
    }
    
    #endregion
    
    #region DaysOfWeek Repository
    
    private static IDaysOfWeekRepository _daysOfWeekRepository = null;
    public static IDaysOfWeekRepository GetDaysOfWeekRepository()
    {
        if (_daysOfWeekRepository == null)
            _daysOfWeekRepository = new DaysOfWeekRepository();
        return _daysOfWeekRepository;
    }
    
    #endregion
    
    #region Grade Repository
    
    private static IGradeRepository _gradeRepository = null;
    public static IGradeRepository GetGradeRepository()
    {
        if (_gradeRepository == null)
            _gradeRepository = new GradeRepository();
        return _gradeRepository;
    }
    
    #endregion
    
    #region Period Repository
    
    private static IPeriodRepository _periodRepository = null;
    public static IPeriodRepository GetPeriodRepository()
    {
        if (_periodRepository == null)
            _periodRepository = new PeriodRepository();
        return _periodRepository;
    }
    
    #endregion
    
    #region Subject Repository
    
    private static ISubjectRepository _subjectRepository = null;
    public static ISubjectRepository GetSubjectRepository()
    {
        if (_subjectRepository == null)
            _subjectRepository = new SubjectRepository();
        return _subjectRepository;
    }
    
    #endregion
    
    #region Schedule Repository
    
    private static IScheduleRepository _scheduleRepository = null;
    public static IScheduleRepository GetScheduleRepository()
    {
        if (_scheduleRepository == null)
            _scheduleRepository = new ScheduleRepository();
        return _scheduleRepository;
    }
    
    #endregion
    
    #region School Repository
    
    private static ISchoolRepository _schoolRepository = null;
    public static ISchoolRepository GetSchoolRepository()
    {
        if (_schoolRepository == null)
            _schoolRepository = new SchoolRepository();
        return _schoolRepository;
    }
    
    #endregion
    
    #region TypesUser Repository
    
    private static ITypeUserRepository _typeUserRepository = null;
    public static ITypeUserRepository GetTypeUserRepository()
    {
        if (_typeUserRepository == null)
            _typeUserRepository = new TypesUserRepository();
        return _typeUserRepository;
    }
    
    #endregion
 
    #region UsersSchedule Repository
    
    private static IUserScheduleRepository _userScheduleRepository = null;
    public static IUserScheduleRepository GetUserScheduleRepository()
    {
        if (_userScheduleRepository == null)
            _userScheduleRepository = new UsersScheduleRepository();
        return _userScheduleRepository;
    }
    
    #endregion
    
    #region UsersSubject Repository
    
    private static IUserSubjectRepository _userSubjectRepository = null;
    public static IUserSubjectRepository GetUserSubjectRepository()
    {
        if (_userSubjectRepository == null)
            _userSubjectRepository = new UsersSubjectRepository();
        return _userSubjectRepository;
    }
    
    #endregion
}