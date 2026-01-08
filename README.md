# TP : Créer et exécuter des tests unitaires en C#

Ce projet a été réalisé dans le cadre du cours d'Enseignement .NET à l'**École Supérieure Polytechnique (ESP)** de l'**Université Cheikh Anta Diop (UCAD)**.

## Objectifs du TP
- Apprendre à créer une bibliothèque de classes en C#.
- Mettre en pratique les tests unitaires avec le framework **MSTest**.
- Gérer les méthodes, les exceptions et le débogage de code.
- Couvrir différents scénarios de test (Débiter, Créditer, Virement).

## Structure du Projet
Le workspace est divisé en deux parties principales :
1.  **BanqueMAHD** : Bibliothèque de classes contenant la logique métier (`CompteBancaire.cs`).
2.  **BanqueTestMAHD** : Projet de tests unitaires contenant les scénarios de validation (`CompteBancaireTests.cs`).

## Problèmes résolus
Lors de la réalisation de ce TP, plusieurs ajustements techniques ont été apportés pour assurer la compatibilité et la robustesse :
- **Compatibilité Environnement** : Les projets ont été configurés pour cibler `.NET Core 2.1` afin de s'adapter au SDK local disponible sur la machine.
- **Correction de Bug** : Correction de la méthode `Débiter` qui effectuait une addition au lieu d'une soustraction (bug intentionnel du TP).
- **Finalisation des Tests** : Implémentation complète des tests pour les cas d'exceptions (montant négatif, solde insuffisant, compte null) en utilisant les attributs `[ExpectedException]`.

## Comment exécuter les tests ?

Pour lancer la suite de tests et vérifier le bon fonctionnement du programme, utilisez la commande suivante dans votre terminal :

```bash
dotnet test BanqueTestMAHD/BanqueTestMAHD.csproj
```

### Résultats attendus
Vous devriez obtenir un résultat confirmant que les **15 tests** passent avec succès :
- Tests de débit (valide, montant négatif, solde insuffisant).
- Tests de crédit (valide, montant négatif).
- Tests de virement (virement valide, virement vers compte null, virement montant négatif).

---
**Année Universitaire** : 2025/2026  
**Département** : Génie Informatique  
**Chargé de Cours** : E. H. Ousmane Diallo  
