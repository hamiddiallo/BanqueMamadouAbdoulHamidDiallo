using System;



namespace BanqueMAHD
{
    /// <summary>
    /// Classe représentant un compte bancaire
    /// </summary>
    public class CompteBancaire
    {
        private string m_nomClient = string.Empty;
        private double m_solde;

        private CompteBancaire() { }

        public CompteBancaire(string nomClient, double solde)
        {
            m_nomClient = nomClient;
            m_solde = solde;
        }

        public string NomClient
        {
            get { return m_nomClient; }
        }

        public double Solde
        {
            get { return m_solde; }
        }

        /// <summary>
        /// Débite un montant du compte
        /// </summary>
        /// <param name="montant">Montant à débiter</param>
        public void Débiter(double montant)
        {
            if (montant > m_solde)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), montant, "Le montant du débit est supérieur au solde");
            }

            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), montant, "Le montant du débit doit être positif");
            }

            m_solde -= montant; // Correction: soustraire le montant
        }

        /// <summary>
        /// Crédite un montant sur le compte
        /// </summary>
        /// <param name="montant">Montant à créditer</param>
        public void Créditer(double montant)
        {
            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), montant, "Le montant du crédit doit être positif");
            }

            m_solde += montant;
        }

        /// <summary>
        /// Effectue un virement vers un autre compte
        /// </summary>
        /// <param name="montant">Montant à virer</param>
        /// <param name="compteBénéficiaire">Compte bénéficiaire</param>
        public void Virement(double montant, CompteBancaire compteBénéficiaire)
        {
            // Validation claire et moderne : lève ArgumentNullException si null
            if (compteBénéficiaire == null)
            {
                throw new ArgumentNullException(nameof(compteBénéficiaire));
            }

            // Débiter le compte source (cela vérifie automatiquement le solde et le montant)
            this.Débiter(montant);

            // Créditer le compte bénéficiaire
            compteBénéficiaire.Créditer(montant);
        }
    }
}