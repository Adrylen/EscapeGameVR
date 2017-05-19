# EscapeGameVR

Futur projet de Réalité Virtuelle de Troisième année à l'ISEN

## Comment ininitaliser le projet ?

### Installer Unity

Il suffit de récupérer l'exécutable de Unity, et de l'installer sur votre Windows ou votre Mac.
Voici le lien du site : 
> https://store.unity.com/download?ref=personal

Bien vérifier que la version est la 5.6 ou supérieure !

### Lancer le projet

Créer un nouveau projet Unity, dans le dossier où vous souhaitez qu'il soit contenu.

### Initialiser le git

A l'aide d'un terminal, aller dans le dossier du projet, et taper les lignes suivantes.

```
git clone https://github.com/Adrylen/EscapeGameVR.git imports
cp -R imports/* imports/.git/ imports/.gitignore .
rm -rf imports
```

Vous aurez alors accès au projet en l'état.

### Coder, c'est la vie

Explicite, à vos claviers !

## Utilisation de Jenkins

Nous possédons pour ce projet un dépôt Jenkins, mit en ligne à l'adresse suivante (encore temporaire)

> http://test.luneau.me

### Comment cela fonctionne ?

Quand vous êtes connecté, vous avez accès au dépôt du projet contenant lui le dépôt git. Le dépôt git est directement relié au GitHub que nous utilisons, et chaque push enclenchera un build complet du projet git.

ATTENTION : Sachez que seuls les scripts C# placés dans le dossier Assets/scripts seront pris en compte !

Si votre build suivant votre push s'est bien passé, la branche où vous avez push s'ornera d'une pastille bleue.
Si votre build s'est mal passé, alors la pastille deviendra rouge.

L'indicateur météo référence les 5 derniers builds, et informe si ceux-là se sont bien passés en moyenne : 

* Soleil : 5/5 derniers builds passés
* Eclaircie : 4/5 derniers builds passés
* Nuageux : 3/5 derniers builds passés
* Pluvieux : 2/5 derniers builds passés
* Orageux : 0-1/5 derniers builds passés

Pour consulter les logs d'un build, cliqué sur son identifiant dans la branche, et allez dans "Console Logs".

Bonne utilisation !

## Slack et les intégrations

### Intégration de GitHub à Slack

La liste des comits effectués lors d'un push sera affichée dans le channel #gitactivity

### Intégration de Jenkins à Slack

On essaie...
