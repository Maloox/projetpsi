import mysql.connector
import json
import os

utilisateur = "root"
mot_de_passe = "Elopes!46mys"
hote = "localhost"
base = "PSI"

conn = mysql.connector.connect(
    host=hote,
    user=utilisateur,
    password=mot_de_passe,
    database=base
)
curseur = conn.cursor()
curseur.execute("SHOW TABLES")
tables = [t[0] for t in curseur.fetchall()]
os.makedirs("exports_json", exist_ok=True)

for table in tables:
    curseur.execute(f"SELECT * FROM {table}")
    colonnes = [desc[0] for desc in curseur.description]
    lignes = curseur.fetchall()
    donnees = [dict(zip(colonnes, ligne)) for ligne in lignes]
    with open(f"exports_json/{table}.json", "w", encoding="utf-8") as f:
        json.dump(donnees, f, indent=4, ensure_ascii=False)

curseur.close()
conn.close()
