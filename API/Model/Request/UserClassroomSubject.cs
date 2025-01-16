using IPCA.Model;

namespace Backend.Model.Request;

public class UserClassroomSubject
{
    private SubjectIPCA _subject;
    private Classroom _classroom;

    public SubjectIPCA Subject
    {
        get => _subject;
        set => _subject = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Classroom Classroom
    {
        get => _classroom;
        set => _classroom = value ?? throw new ArgumentNullException(nameof(value));
    }
}