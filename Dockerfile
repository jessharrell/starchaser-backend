FROM postgres
ENV POSTGRES_PASSWORD docker
ENV POSTGRESS_DB starchaser
COPY starchaser.sql /docker-enterypoint-initdb.d/
