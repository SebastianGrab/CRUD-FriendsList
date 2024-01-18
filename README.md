# CRUD-FriendsList

## Run the App:

### Database:

docker-compose up -d db

docker exec -it db psql -U postgres

CREATE TABLE "myFriends" (
  "id" SERIAL PRIMARY KEY,
  "name" VARCHAR(50) NOT NULL,
  "email" VARCHAR(255) NOT NULL,
  "phone" VARCHAR(255) NOT NULL,
  "dob" VARCHAR(255) NOT NULL
);

exit


### Backend:

docker-compose up -d csharp_app


### Frontend

Adjust _apiBaseUrl in [FriendsController.cs](/frontend/Controllers/FriendsController.cs)

docker-compose up -d ui
