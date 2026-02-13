# Authentification JWT

Le projet utilise **JWT** pour sécuriser l’API.

## Users

Exemples :

| Username | Password | Role  |
|----------|---------|-------|
| admin    | admin   | Admin |
| user     | user    | User  |

## API Endpoints

- `POST /api/auth/login`
  - Body : `{ "username": "admin", "password": "admin" }`
  - Retour : `{ "token": "..." }`

### Utilisation du token

- Ajouter un header `Authorization: Bearer <token>` pour accéder aux endpoints sécurisés.

