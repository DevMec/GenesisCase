# GenesisCase
GenesisCase
For the meeting of 04/06/2020 at 16:OO

Pour lancer le projet:
1-	Ouvrir avec Visual studio (ici 2019).
2-	Mettre le projet 1-Services/ Genesis en “Startup Project”.
3-	Vérifier que la start page est : http://localhost:5281/swagger

Pour l’instant, j’utilise swagger pour pouvoir interroger mes services (j’ai l’habitude d’utiliser fiddler pour voir avoir plus de contrôles sur les requêtes).

4-	Ensuite builder et démarrer la solution.

5-	J’ai ajouté un projet de tests pour les Contraintes business (Pas vraiment nécessaire car les besoin business sont simplistes)

6- Ne pas oublié de changer la ConnectionString en fonction de vos paramètre.
J'ai ajouté un fichier Data/GenesisCase.mdf dans le projet Repository.

7- Il y a deux fichiers postman (environment et testCollection).
pour les tests collections executer le save puis GetAll pour recuperer les l'id generé, pour mettre a jour les variables.

Bien à vous,
