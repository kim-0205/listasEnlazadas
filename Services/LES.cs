using listasEnlazadas.Models;

namespace listasEnlazadas.Services
{
    public class LES
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }

        public LES()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }

        private bool EstaVacia()
        {
            return PrimerNodo == null;
        }

        public string AgregarNodoInicio(Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
            }
            return "Nodo agregado al inicio de la lista";
        }

        public string AgregarNodoFinal(Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.Referencia = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            return "Nodo agregado al final de la lista";
        }

        public string AgregarAntesDeX(string x, Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                return "No se puede insertar antes, la lista está vacía.";
            }

            if (PrimerNodo.Informacion == x)
            {
                return AgregarNodoInicio(nuevoNodo);
            }

            Nodo actual = PrimerNodo;
            while (actual.Referencia != null && actual.Referencia.Informacion != x)
            {
                actual = actual.Referencia;
            }

            if (actual.Referencia == null)
            {
                return "No se encontró el valor en la lista.";
            }

            nuevoNodo.Referencia = actual.Referencia;
            actual.Referencia = nuevoNodo;
            return "Nodo agregado antes de " + x;
        }

        public string AgregarDespuesDeX(string x, Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                return "No se puede insertar después, la lista está vacía.";
            }

            Nodo actual = PrimerNodo;
            while (actual != null && actual.Informacion != x)
            {
                actual = actual.Referencia;
            }

            if (actual == null)
            {
                return "No se encontró el valor en la lista.";
            }

            nuevoNodo.Referencia = actual.Referencia;
            actual.Referencia = nuevoNodo;

            if (actual == UltimoNodo)
            {
                UltimoNodo = nuevoNodo;
            }

            return "Nodo agregado después de " + x;
        }

        public string AgregarEnPosicion(int posicion, Nodo nuevoNodo)
        {
            if (posicion < 1)
            {
                return "La posición debe ser mayor o igual a 1.";
            }

            if (posicion == 1)
            {
                return AgregarNodoInicio(nuevoNodo);
            }

            Nodo actual = PrimerNodo;
            int contador = 1;

            while (actual != null && contador < posicion - 1)
            {
                actual = actual.Referencia;
                contador++;
            }

            if (actual == null)
            {
                return "La posición especificada está fuera de rango.";
            }

            nuevoNodo.Referencia = actual.Referencia;
            actual.Referencia = nuevoNodo;

            if (nuevoNodo.Referencia == null)
            {
                UltimoNodo = nuevoNodo;
            }

            return "Nodo agregado en la posición " + posicion;
        }

        public string AgregarAntesDePosicion(int posicion, Nodo nuevoNodo)
        {
            if (posicion < 2)
            {
                return AgregarNodoInicio(nuevoNodo);
            }
            return AgregarEnPosicion(posicion - 1, nuevoNodo);
        }

        public string AgregarDespuesDePosicion(int posicion, Nodo nuevoNodo)
        {
            return AgregarEnPosicion(posicion + 1, nuevoNodo);
        }

        public void RecorrerRecursivo(Nodo nodo, List<string> elementos)
        {
            if (nodo == null)
            {
                return;
            }

            elementos.Add(nodo.Informacion);
            RecorrerRecursivo(nodo.Referencia, elementos);
        }

        public List<int> BuscarPosiciones(string valor)
        {
            List<int> posiciones = new List<int>();
            Nodo actual = PrimerNodo;
            int posicion = 1;

            while (actual != null)
            {
                if (actual.Informacion == valor)
                {
                    posiciones.Add(posicion); 
                }
                actual = actual.Referencia;
                posicion++;
            }

            return posiciones;
        }

    }
}
