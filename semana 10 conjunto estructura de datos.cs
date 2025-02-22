using System;
using System.Collections.Generic;
using System.IO;

class Ciudadano
{
    public string Nombre { get; set; }
    public string EstadoVacunacion { get; set; } // "No vacunado", "Una dosis", "Dos dosis - Pfizer", "Dos dosis - Astrazeneca"

    public Ciudadano(string nombre, string estadoVacunacion)
    {
        Nombre = nombre;
        EstadoVacunacion = estadoVacunacion;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Ciudadano> ciudadanos = new List<Ciudadano>();
        GenerarDatosCiudadanos(ciudadanos);

        List<Ciudadano> noVacunados = ciudadanos.FindAll(c => c.EstadoVacunacion == "No vacunado");
        List<Ciudadano> vacunadosDosDosis = ciudadanos.FindAll(c => c.EstadoVacunacion == "Dos dosis - Pfizer" || c.EstadoVacunacion == "Dos dosis - Astrazeneca");
        List<Ciudadano> soloPfizer = ciudadanos.FindAll(c => c.EstadoVacunacion == "Dos dosis - Pfizer");
        List<Ciudadano> soloAstrazeneca = ciudadanos.FindAll(c => c.EstadoVacunacion == "Dos dosis - Astrazeneca");

        // Guardar resultados en archivos
        GuardarResultados("no_vacunados.txt", noVacunados);
        GuardarResultados("vacunados_dos_dosis.txt", vacunadosDosDosis);
        GuardarResultados("solo_pfizer.txt", soloPfizer);
        GuardarResultados("solo_astrazeneca.txt", soloAstrazeneca);

        Console.WriteLine("Los datos han sido generados y guardados en archivos de texto.");
    }

    static void GenerarDatosCiudadanos(List<Ciudadano> ciudadanos)
    {
        Random rand = new Random();
        string[] estados = { "No vacunado", "Una dosis", "Dos dosis - Pfizer", "Dos dosis - Astrazeneca" };

        for (int i = 1; i <= 500; i++)
        {
            string nombre = "Ciudadano " + i;
            // Asignar un estado de vacunación aleatorio
            string estadoVacunacion = estados[rand.Next(estados.Length)];
            ciudadanos.Add(new Ciudadano(nombre, estadoVacunacion));
        }
    }

    static void GuardarResultados(string nombreArchivo, List<Ciudadano> ciudadanos)
    {
        using (StreamWriter sw = new StreamWriter(nombreArchivo))
        {
            foreach (var ciudadano in ciudadanos)
            {
                sw.WriteLine(ciudadano.Nombre);
            }
        }
    }
}
