using BanqueMAHD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BanqueTestMAHD
{
    [TestClass]
    public class CompteBancaireTests
    {
        // ============================================
        // TESTS POUR LA MÉTHODE DÉBITER
        // ============================================

        [TestMethod]
        public void VérifierDébitCompteCorrect()
        {
            // Arrange - Préparation
            double soldeInitial = 11.99;
            double montantDébit = 4.55;
            double soldeAttendu = 7.44;
            CompteBancaire compte = new CompteBancaire("M. Dupont", soldeInitial);

            // Act - Action
            compte.Débiter(montantDébit);

            // Assert - Vérification
            double soldeRéel = compte.Solde;
            Assert.AreEqual(soldeAttendu, soldeRéel, 0.001, "Le compte n'a pas été débité correctement");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DébiterMontantSupérieurAuSolde_DoitLeverException()
        {
            // Arrange
            double soldeInitial = 100.0;
            double montantDébit = 150.0;
            CompteBancaire compte = new CompteBancaire("M. Martin", soldeInitial);

            // Act
            compte.Débiter(montantDébit);

            // Assert - Exception attendue
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DébiterMontantNégatif_DoitLeverException()
        {
            // Arrange
            double soldeInitial = 100.0;
            double montantDébit = -50.0;
            CompteBancaire compte = new CompteBancaire("Mme Durand", soldeInitial);

            // Act
            compte.Débiter(montantDébit);

            // Assert - Exception attendue
        }

        [TestMethod]
        public void DébiterMontantZéro_SoldeInchangé()
        {
            // Arrange
            double soldeInitial = 100.0;
            double montantDébit = 0.0;
            CompteBancaire compte = new CompteBancaire("M. Bernard", soldeInitial);

            // Act
            compte.Débiter(montantDébit);

            // Assert
            Assert.AreEqual(soldeInitial, compte.Solde, 0.001, "Le solde doit rester inchangé après un débit de zéro");
        }

        [TestMethod]
        public void DébiterToutLeSolde_SoldeÀZéro()
        {
            // Arrange
            double soldeInitial = 100.0;
            CompteBancaire compte = new CompteBancaire("Mme Thomas", soldeInitial);

            // Act
            compte.Débiter(soldeInitial);

            // Assert
            Assert.AreEqual(0.0, compte.Solde, 0.001, "Le solde doit être à zéro après avoir débité tout le solde");
        }

        // ============================================
        // TESTS POUR LA MÉTHODE CRÉDITER
        // ============================================

        [TestMethod]
        public void CréditerMontantValide_AugmenteLeSolde()
        {
            // Arrange
            double soldeInitial = 100.0;
            double montantCrédit = 50.0;
            double soldeAttendu = 150.0;
            CompteBancaire compte = new CompteBancaire("M. Petit", soldeInitial);

            // Act
            compte.Créditer(montantCrédit);

            // Assert
            Assert.AreEqual(soldeAttendu, compte.Solde, 0.001, "Le compte n'a pas été crédité correctement");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CréditerMontantNégatif_DoitLeverException()
        {
            // Arrange
            double soldeInitial = 100.0;
            double montantCrédit = -50.0;
            CompteBancaire compte = new CompteBancaire("Mme Robert", soldeInitial);

            // Act
            compte.Créditer(montantCrédit);

            // Assert - Exception attendue
        }

        [TestMethod]
        public void CréditerMontantZéro_SoldeInchangé()
        {
            // Arrange
            double soldeInitial = 100.0;
            double montantCrédit = 0.0;
            CompteBancaire compte = new CompteBancaire("M. Richard", soldeInitial);

            // Act
            compte.Créditer(montantCrédit);

            // Assert
            Assert.AreEqual(soldeInitial, compte.Solde, 0.001, "Le solde doit rester inchangé après un crédit de zéro");
        }

        [TestMethod]
        public void CréditerPlusieursMonants_SoldeCorrect()
        {
            // Arrange
            double soldeInitial = 100.0;
            CompteBancaire compte = new CompteBancaire("Mme Dubois", soldeInitial);

            // Act
            compte.Créditer(25.0);
            compte.Créditer(50.0);
            compte.Créditer(25.0);

            // Assert
            double soldeAttendu = 200.0;
            Assert.AreEqual(soldeAttendu, compte.Solde, 0.001, "Le solde après plusieurs crédits n'est pas correct");
        }

        // ============================================
        // TESTS POUR LA MÉTHODE VIREMENT
        // ============================================

        [TestMethod]
        public void VirementMontantValide_TransfertCorrect()
        {
            // Arrange
            double soldeSource = 200.0;
            double soldeBénéficiaire = 100.0;
            double montantVirement = 75.0;
            CompteBancaire compteSource = new CompteBancaire("M. Moreau", soldeSource);
            CompteBancaire compteBénéficiaire = new CompteBancaire("Mme Laurent", soldeBénéficiaire);

            // Act
            compteSource.Virement(montantVirement, compteBénéficiaire);

            // Assert
            Assert.AreEqual(125.0, compteSource.Solde, 0.001, "Le solde du compte source n'est pas correct après le virement");
            Assert.AreEqual(175.0, compteBénéficiaire.Solde, 0.001, "Le solde du compte bénéficiaire n'est pas correct après le virement");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VirementMontantSupérieurAuSolde_DoitLeverException()
        {
            // Arrange
            double soldeSource = 50.0;
            double soldeBénéficiaire = 100.0;
            double montantVirement = 100.0;
            CompteBancaire compteSource = new CompteBancaire("M. Simon", soldeSource);
            CompteBancaire compteBénéficiaire = new CompteBancaire("Mme Michel", soldeBénéficiaire);

            // Act
            compteSource.Virement(montantVirement, compteBénéficiaire);

            // Assert - Exception attendue
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VirementVersCompteNull_DoitLeverException()
        {
            // Arrange
            double soldeSource = 200.0;
            double montantVirement = 50.0;
            CompteBancaire compteSource = new CompteBancaire("M. Lefebvre", soldeSource);

            // Act
            compteSource.Virement(montantVirement, null);

            // Assert - Exception attendue
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VirementMontantNégatif_DoitLeverException()
        {
            // Arrange
            double soldeSource = 200.0;
            double soldeBénéficiaire = 100.0;
            double montantVirement = -50.0;
            CompteBancaire compteSource = new CompteBancaire("M. Leroy", soldeSource);
            CompteBancaire compteBénéficiaire = new CompteBancaire("Mme Fournier", soldeBénéficiaire);

            // Act
            compteSource.Virement(montantVirement, compteBénéficiaire);

            // Assert - Exception attendue
        }

        [TestMethod]
        public void VirementMontantZéro_SoldesInchangés()
        {
            // Arrange
            double soldeSource = 200.0;
            double soldeBénéficiaire = 100.0;
            double montantVirement = 0.0;
            CompteBancaire compteSource = new CompteBancaire("M. Girard", soldeSource);
            CompteBancaire compteBénéficiaire = new CompteBancaire("Mme Bonnet", soldeBénéficiaire);

            // Act
            compteSource.Virement(montantVirement, compteBénéficiaire);

            // Assert
            Assert.AreEqual(soldeSource, compteSource.Solde, 0.001, "Le solde du compte source ne doit pas changer");
            Assert.AreEqual(soldeBénéficiaire, compteBénéficiaire.Solde, 0.001, "Le solde du compte bénéficiaire ne doit pas changer");
        }

        [TestMethod]
        public void VirementEntreDeuxComptes_Réversible()
        {
            // Arrange
            double soldeInitial1 = 200.0;
            double soldeInitial2 = 100.0;
            CompteBancaire compte1 = new CompteBancaire("M. Garnier", soldeInitial1);
            CompteBancaire compte2 = new CompteBancaire("Mme Rousseau", soldeInitial2);

            // Act - Virement aller
            compte1.Virement(50.0, compte2);
            // Virement retour
            compte2.Virement(50.0, compte1);

            // Assert - Les soldes doivent revenir à leur état initial
            Assert.AreEqual(soldeInitial1, compte1.Solde, 0.001, "Le solde du compte 1 doit revenir à l'état initial");
            Assert.AreEqual(soldeInitial2, compte2.Solde, 0.001, "Le solde du compte 2 doit revenir à l'état initial");
        }
    }
}