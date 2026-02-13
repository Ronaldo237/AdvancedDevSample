
# Gestion des commandes

## Entités

- `Order` : contient `Id`, `OrderLines`, `TotalAmount`

## Services

- `OrderService` :
  - `CreateAsync(CreateOrderDto dto)`
  - `DeleteAsync(Guid id)`
  - `GetByIdAsync(Guid id)`
  - `GetAllAsync()`

## API Endpoints

- `GET /api/orders` : liste toutes les commandes
- `GET /api/orders/{id}` : récupère une commande
- `POST /api/orders` : crée une commande
- `DELETE /api/orders/{id}` : supprime une commande
