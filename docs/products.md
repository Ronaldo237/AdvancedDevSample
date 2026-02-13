# Gestion des produits

## Entités

- `Product` : contient `Id`, `Price`, `IsActive`
- `Price` : Value Object pour la valeur et la validation

## Services

- `ProductService` :
  - `CreateAsync(CreateProductDto dto)`
  - `UpdateAsync(Guid id, UpdateProductDto dto)`
  - `DeleteAsync(Guid id)`
  - `GetByIdAsync(Guid id)`
  - `GetAllAsync()`

## API Endpoints

- `GET /api/products` : liste tous les produits
- `GET /api/products/{id}` : récupère un produit
- `POST /api/products` : crée un produit
- `PUT /api/products/{id}` : met à jour un produit
- `DELETE /api/products/{id}` : supprime un produit

