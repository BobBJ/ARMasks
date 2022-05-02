# AM3 - AR Masks

Application mobile qui permet de transférer un visage sur la tête de l’utilisateur en réalité augmentée. Il y a 6 boutons qui permettent plusieurs actions.

## Installation 

Pour installer et faire fonctionner pleinement l'application. Il faut installer Python 3 ainsi que les dépendances sur un PC pour pouvoir lancer manuellement les traitements d'images
```bash
    sudo pip3 install chardet requests random json Image numpy skimage collections dlib cv2 matplotlib.pyplot os glob 
```

## Organisation de l'archive

 
        /.vscode 		    Utile pour le debug de Visual studio code.
        /BackUpsAPK		Contient les apk antérieurs permettant d’installer l’application aux différentes étapes de son développement.
        /Partie AR Masks	S’occupe de la gestion des masques appliqués sur la tête de l’utilisateur.
	    /Python			Gère les requêtes de communication entre le portable et le pc qui traite l’image.
	    .gitignore		Exclu les librairies et les fichiers temporaires qu’Unity a besoin.
	    sample.jpg		Utile pour de la sauvegarde.

	
	
## Utilisation

Pour utiliser pleinement l'application, il faut en plus du téléphone, utiliser un pc permettant d'executer le script python "greeter.py". Il permettra de traiter les images envoyées depuis le téléphone. Pour lancer le script, il faut se placer dans le dossier /Python de l'archive.

## Aperçu de l'application mobile

![alt text](https://zupimages.net/up/22/18/w6ns.jpg)   
    
## Boutons de l'application

    
![alt text](https://zupimages.net/up/22/18/l0zq.png)            1 - Bouton qui prend une photo et l’envoie vers le canal slack pour que python puisse la traiter.
	  
![alt text](https://zupimages.net/up/22/18/0dah.png)	        2 - Bouton qui récupère la photo traitée sur le canal slack. 

![alt text](https://zupimages.net/up/22/18/ygbg.png)	        3 - Bouton qui ajoute le masque du visage téléchargé sur la tête de l’utilisateur.

![alt text](https://zupimages.net/up/22/18/0r4k.png)	        4 - Bouton qui enlève le masque qui est sur la tête de l’utilisateur.

![alt text](https://zupimages.net/up/22/18/6otk.png)	        5 - Bouton qui change le masque qui est sur la tête de l’utilisateur.

![alt text](https://zupimages.net/up/22/18/6cyt.png)        	6 - Bouton qui permet de prendre une photo de la tête de l’utilisateur et la sauvegarder dans la galerie de son téléphone.

    
## Fonctionnalitées et détails

    Prendre une photo de l'utilisateur avec ou sans un masque (appuyer sur le bouton n°6)
        * L'image est enregistré dans la gallerie. Elle nécessite une carte SD dans le téléphone
    
    Afficher un masque changeable sur la tête de l'utilisateur
        * L'affichage est automatiquement lancé au démarrage de l'application
            - Il peut être intérompu et relancé avec le bouton n°4
        * Le masque est interchangeable entre 3 masques prédéfinies avec le bouton n°5
        * L'utilisateur peut aussi choisir comme masque l'image qu'il a téléchargé précédement avec le bouton n°3
            - Il faut qu'il ait au moins fait le processus de création de masque une fois
    
    Création d'un masque personnalisé et choix de ce masque
        * Etape 1 ) L'utilisateur doit déja envoyer une photo contenant un visage avec le bouton n°1
            - Quand ce bouton est appuyé, il prendra une capture d'écran qu'il enverra au PC
        * Etape 2 ) L'utilisateur doit lancer le script de traitement d'image depuis le PC
            - Il faut attendre un court laps de temps avant de le lancer pour être sûr que le serveur a bien reçu l'image du téléphone
        * Etape 3 ) L'utilisateur peut récupérer l'image traité avec le bouton n°2
            - L'image est sauvegardé sur un fichier permanent, il peut donc garder en mémoire un masque personnalisé
        * Etape 4 ) L'utilisateur peut choisir d'utiliser le masque personnalisé reçu à la place du masque prédéfini avec le bouton n°3
        

## Erreurs possibles avec Python 
    
    Problèmes avec la clé ['files'] :
        - L'utilisateur a demandé à Python de rendre une image publique qui était déjà publique. C'est souvent dû à la latence du serveur Slack qui met un court laps de temps à détecter une nouvelle image
    
    Problèmes d'index avec dlib : 
        - L'image utilisé est trop grosse (la face prend trop de place sur l'image). Souvent c'est dû au fait que la face dans l'image source est trop proche de l'écran
    
## Erreurs possibles avec le masque personnalisé

    Le masque personnalisé contient la tête entière et pas seulement la face :  
        - Le serveur de Slack étant un peu lent, quand l'utilisateur a acquérit la dernière image stockée dans Slack, il a obtenu celle non-traitée. Il faut attendre avant de relancer le download de cette image. Il est aussi possible que le script Python n'est pas été lancé. Il n'y a donc pas d'image traitée à utiliser.
    
## Créateurs
    
    BEN JEMIA Boran (p1924945)
    
    ROULLIER LEA (p1911736)
    
    BOMBOURG VINCENT (p1911214)
    

    
    
