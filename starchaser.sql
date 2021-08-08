BEGIN

CREATE TABLE character (
    id integer NOT NULL,
    name text NOT NULL,
    health integer NOT NULL,
    bio text,
    homeplanet integer NOT NULL
);

CREATE TABLE planet (
    id integer NOT NULL,
    name text NOT NULL,
    description text NOT NULL
);

INSERT INTO character(id, name, health, bio, homeplanet)
VALUES 
    (0, "Clark", 50, "Loves his family and to take vacations. Christmas lighting skills are second to none", 0)
    (1, "Blerg", 350, "Eats everything insight. has constant indigestion", 1)
    (2, "Zandar the Great", 100, "Believes he is the greatest of all time. Howeever is head is too large to fit in most doorways", 2)
    (3, "Winny", 120, "Small mouse", 2);

INSERT INTO planet(id, name, description)
VALUES
    (0, "Earth", "The blue planet")
    (1, "DZerek", "On the edge of Galaxy 478, exists a greasy planet home to the Balgarg species.")
    (2, "Planet Hollywood", "Home to the stars amongst the stars");

ALTER TABLE ONLY character
    ADD CONSTRAINT character_pkey PRIMARY KEY (id);

ALTER TABLE ONLY plaent
    ADD CONSTRAINT planet_pkey PRIMARY KEY (id);

ALTER TABLE ONLY character
    ADD CONSTRAINT homeplanet_fkey FOREIGN KEY (homeplant) REFERENCES planet(id);

COMMIT;
