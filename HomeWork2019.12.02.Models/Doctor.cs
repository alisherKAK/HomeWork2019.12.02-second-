using HomeWork2019._12._02.AbstractModels;

namespace HomeWork2019._12._02.Models
{
    public class Doctor : IEntity
    {
        public int Id { get; set; }
        public string Specialist { get; set; }
        public string SpecialistFullName { get; set; }
    }
}
