
# Architecture du projet

Le projet suit la **Clean Architecture** :

AdvancedDevSample/
├─ AdvancedDevSample.Domain # Entités, exceptions, interfaces
├─ AdvancedDevSample.Application # Services, DTOs
├─ AdvancedDevSample.Infrastructure # Repositories
├─ AdvancedDevSample.API # Contrôleurs, middlewares
├─ AdvancedDevSample.Tests # Tests unitaires et intégration
└─ docs # Documentation


### Layers

- **Domain** : logiques métier, Value Objects, Entités
- **Application** : services applicatifs, DTOs
- **Infrastructure** : accès aux données, implémentations des interfaces
- **API** : points d’entrée, controllers, middlewares
- **Tests** : tests unitaires et intégration

