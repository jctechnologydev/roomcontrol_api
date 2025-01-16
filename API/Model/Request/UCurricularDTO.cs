using IPCA.Model;

namespace Backend.Model.Request;

public class UCurricularDTO
{
    private int id;
    private string name;
    private Classroom room;

    public UCurricularDTO() { }
    public UCurricularDTO(SubjectIPCA subjectIpca, Classroom room)
    {
        this.id = subjectIpca.IdSubject;
        this.name = subjectIpca.Subject;
        this.room = room;
    }

    public int Id
    {
        get => id;
        set => id = value;
    }

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Classroom Room
    {
        get => room;
        set => room = value ?? throw new ArgumentNullException(nameof(value));
    }
}