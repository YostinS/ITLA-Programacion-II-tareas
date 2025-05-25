public class MiembroDeLaComunidad
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public int Genero { get; set; }

    public void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}, Genero: {Genero}");
    }
}
public class Empleado : MiembroDeLaComunidad
{
    public string Cargo { get; set; }

    public void MostrarInfo()
    {
        base.MostrarInfo();
        Console.WriteLine($"Cargo: {Cargo}");
    }
}
public class Estudiante : MiembroDeLaComunidad
{
    public string Carrera { get; set; }
    public string Matricula { get; set; }

    public void MostrarInfo()
    {
        base.MostrarInfo();
        Console.WriteLine($"Carrera: {Carrera}, Matricula: {Matricula}");
    }
}
public class ExAlumno : MiembroDeLaComunidad
{
    public int FechaEgreso { get; set; }

    public  void MostrarInfo()
    {
        base.MostrarInfo();
        Console.WriteLine($"Fecha de Egreso: {FechaEgreso}");
    }
}
public class Docente : Empleado
{
    public string Materia { get; set; }

    public void MostrarInfo()
    {
        base.MostrarInfo();
        Console.WriteLine($"Materia a impartir: {Materia}");
    }
}
public class Administrador : Docente
{
    public string NivelAcceso { get; set; }

    public void MostrarInfo()
    {
        base.MostrarInfo();
        Console.WriteLine($"Nivel de Acceso: {NivelAcceso}");
    }
}
