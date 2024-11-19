using SegundoParcialRombo.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialRombo.Datos
{
    public class Repositorio
    {
        private List<Rombo> ListaDeRombos;
        private string? nombreArchivo = "Rombos.txt";
        private string? rutaProyecto = Environment.CurrentDirectory;
        private string? rutaCompletaArchivo;
        public Repositorio()
        {
            ListaDeRombos = LeerDatos();

        }
        public List<Rombo> ObtenerRombo()
        {
            return new List<Rombo>(ListaDeRombos);
        }
        public int GetCantidad(Contorno? contornoSeleccionado = null)
        {
            if (contornoSeleccionado == null)
                return ListaDeRombos.Count;
            return ListaDeRombos.Count(e => e.contornos == contornoSeleccionado);
        }
        public void AgregarRombo(Rombo rombo)
        {
            ListaDeRombos.Add(rombo);
        }
        public void EliminarRombo(Rombo rombo)
        {
            ListaDeRombos.Remove(rombo);
        }
        public void GuardarDatos()
        {
            rutaCompletaArchivo = Path.Combine(rutaProyecto, nombreArchivo);
            using (var escritor = new StreamWriter(rutaCompletaArchivo))
            {
                foreach (var rombo in ListaDeRombos)
                {
                    string linea = ConstruirLinea(rombo);
                    escritor.WriteLine(linea);
                }
            }
        }
        public bool Existe(Rombo rombo)
        {
            return ListaDeRombos.Any(e => e.DiagonalMenor == rombo.DiagonalMenor &&
                e.DiagonalMayor == rombo.DiagonalMayor);
        }

        private string ConstruirLinea(Rombo rombo)
        {
            return $"{rombo.DiagonalMayor}|{rombo.DiagonalMenor}|{rombo.contornos.GetHashCode()}";
        }
        

        

        private List<Rombo>? LeerDatos()
        {
            var listaRombo = new List<Rombo>();
            rutaCompletaArchivo = Path.Combine(rutaProyecto, nombreArchivo);
            if (!File.Exists(rutaCompletaArchivo))
            {
                return listaRombo;
            }
            using (var lector = new StreamReader(rutaCompletaArchivo))
            {
                while (!lector.EndOfStream)
                {
                    string? linea = lector.ReadLine();
                    Rombo? elipse = ConstruirRombo(linea);
                    listaRombo.Add(elipse!);
                }
            }
            return listaRombo;
        }

        private Rombo? ConstruirRombo(string? linea)
        {
            var campos = linea!.Split('|');
            var dM = int.Parse(campos[0]);
            var dm = int.Parse(campos[1]);
            var contornos = (Contorno)int.Parse(campos[2]);
            return new Rombo(dM, dm, contornos);
        }
    }
}
