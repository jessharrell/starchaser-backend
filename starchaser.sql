CREATE USER docker WITH PASSWORD 'docker';

CREATE TABLE planets (
    planetId integer GENERATED ALWAYS AS IDENTITY,
    name varchar(25) NOT NULL,
    description varchar(365) NOT NULL,
    PRIMARY KEY(planetId)
);

CREATE TABLE characters (
    characterId integer GENERATED ALWAYS AS IDENTITY,
    name varchar(25) NOT NULL,
    health integer NOT NULL,
    bio varchar(1024),
    planetId integer NOT NULL,
    PRIMARY KEY(characterId),
    CONSTRAINT fk_planet
        FOREIGN KEY(planetId)
            REFERENCES planets(planetId)
);

GRANT CONNECT ON DATABASE postgres TO docker;
GRANT ALL ON SCHEMA public TO docker;
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO docker;

INSERT INTO planets(name, description)
VALUES
    ('Earth', 'The blue planet'),
    ('DZerek', 'On the edge of Galaxy 478, exists a greasy planet home to the Balgarg species.'),
    ('Planet Hollywood', 'Home to the stars amongst the stars');

INSERT INTO characters(name, health, bio, planetId)
VALUES 
    ('Clark', 50, 'Loves his family and to take vacations. Christmas lighting skills are second to none', 1),
    ('Blerg', 350, 'Eats everything insight. has constant indigestion', 2),
    ('Zandar the Great', 100, 'Believes he is the greatest of all time. Howeever is head is too large to fit in most doorways', 3),
    ('Winny', 120, 'Small mouse', 3);
