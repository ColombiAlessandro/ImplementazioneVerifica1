using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementazioneVerifica1
{
    class Program
    {
        static void Main(string[] args)
        {
            ContoCorrente conto1 = new ContoCorrente("PASDJGF", "Diego Bernini", "Intesa San Paolo", 0);
            ContoCorrente conto2 = new ContoCorrente("AASAFSF", "olprofesur", "Intesa San Paolo", 0);
            conto1.deposita(100);
            conto1.preleva(50);
            conto2.deposita(1000);
            conto2.preleva(2000);
            conto1.bonifico(conto2, 50);
            CartaBancomat carta1 = new CartaBancomat(conto1,"PASIFJIASJF", "5342 3211 9384 1923");
            CartaBancomat carta2 = new CartaBancomat(conto2,"ASFGASDASJF", "5342 4211 9384 1413");
            carta1.deposita(40);
            carta2.preleva(50);
            Console.WriteLine(carta1.getSaldo());
            Console.WriteLine(carta2.getSaldo());

        }
    }
    class ContoCorrente
    {
        private string _id;
        private string _cliente;
        private string _banca;
        private float _saldo;

        public ContoCorrente(string id, string cliente, string banca, float saldo)
        {
            ID = id;
            Cliente = cliente;
            Banca = banca;
            Saldo = saldo;
        }
        public string ID
        {
            private set
            {
                _id = value;
            }
            get
            {
                return _id;
            }
        }
        public string Banca
        {
            private set
            {
                _banca = value;
            }
            get
            {
                return _banca;
            }
        }
        public string Cliente
        {
            private set
            {
                _cliente = value;
            }
            get
            {
                return _cliente;
            }
        }
        public float Saldo
        {
            set
            {
                _saldo = value;
            }
            get
            {
                return _saldo;
            }
        }
        public void deposita(float somma)
        {
            _saldo += somma;
        }
        public void preleva(float somma)
        {
            if (_saldo - somma >= 0)
            {
                _saldo -= somma;
            }
        }
        public void bonifico(ContoCorrente destinazione, float somma)
        {
            if (Saldo - somma >= 0)
            {
                destinazione.Saldo += somma;
                Saldo -= somma;
            }
        }
    }
    class CartaBancomat
    {
        private ContoCorrente conto;
        private string _id;
        private string _pin;
        
        public CartaBancomat(ContoCorrente conto, string id, string pin)
        {
            this.conto = conto;
            ID = id;
            Pin = pin;
        }
        public string ID
        {
            get
            {
                return _id;
            }
            private set
            {
                _id = value;
            }
        }
        private string Pin
        {
            get
            {
                return _pin;
            }
            set
            {
                _pin = value;
            }
        }
        public void deposita(float somma)
        {
            conto.deposita(somma);
        }
        public void preleva(float somma)
        {
            conto.preleva(somma);
        }
        public float getSaldo()
        {
            return conto.Saldo;
        }
    }
    class SportelloBancomat
    {
        private string _id;
        private string _indirizzo;
        private string _banca;
        private CartaBancomat carta;
        private bool disponibilita=true;

        public string ID
        {
            get
            {
                return _id;
            }
        }
        public string Banca
        {
            get
            {
                return _banca;
            }
        }
        public string Indirizzo
        {
            get
            {
                return _indirizzo;
            }
        }
        public void inserisci(CartaBancomat nuovaCarta)
        {
            if (disponibilita)
            {
                carta = nuovaCarta;
                disponibilita = false;
            }
        }
        public CartaBancomat rimuovi()
        {
            if (!disponibilita)
            {
                carta = null;
                disponibilita = true;
                return carta;
            }
            return null;
        }


    }
}
