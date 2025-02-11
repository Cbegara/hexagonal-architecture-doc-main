db = db.getSiblingDB("gtmotive");
db.createUser({
  user: "rootuser",
  pwd: "rootpass",
  roles: [{ role: "readWrite", db: "gtmotive" }]
});

db.createCollection("Customers");
db.createCollection("Rentals");
db.createCollection("Vehicles");
