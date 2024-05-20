using PostSharp.Aspects;
using System;
public class Juicio : ArchivoPolicial{
    Investigacion InvestigacionJuzgado;
    int idJuez;
    DateTime fechaJuicio;

    public Juicio(int d, Investigacion c, int j, DateTime f){
        idArchivo = d;
        InvestigacionJuzgado = c;
        idJuez = j;
        fechaJuicio = f;
    }
    [RegistroAspecto]
    public void setFecha(DateTime f, string pwd){
      
        if (pwd != "contraseña")
        {
            throw new InvalidOperationException("Contraseña incorrecta. No se puede establecer la fecha.");
        }
        fechaJuicio = f;
    }

    [RegistroAspecto]
    public override void mostrarDetalles(int placa){
        Console.WriteLine("+--------------------------------------+");
        Console.WriteLine("|          Detalles del Juicio         |");
        Console.WriteLine("+--------------------------------------+");
        Console.WriteLine("| Se celebra un juicio sobre el Investigacion " + InvestigacionJuzgado.getId() + "\n");
        Console.WriteLine("| Dirigido por el Juez " + idJuez + "\n");
        Console.WriteLine("| En la fecha " + fechaJuicio + "\n");
        Console.WriteLine("+--------------------------------------+");
    }

    [RegistroAspecto]
    public override void solicitarRevision(int placa){
        Console.WriteLine("+-------------------------------------------------+");
        Console.WriteLine("|                     Revisión                    |");
        Console.WriteLine("+-------------------------------------------------+");
        Console.WriteLine("| Enviado una solicitud de revisión del juicio");
        Console.WriteLine("+-------------------------------------------------+");
    }
}