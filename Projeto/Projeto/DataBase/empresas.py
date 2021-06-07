import re

contentRE = re.compile(
    r'\d+:{.+\n"symbol":"(.+)"\n"name":"(.+)"\n"currency":"(.+)"\n"exchange":"(.+)"\n"country":"(.+)"\n"type":"(.+)"\n}')

empresas = open('empresas.sql','w+',encoding='utf-8')
acoes = open('acoes.sql','w+',encoding='utf-8')

with open("empresas.txt") as e:
    file = e.read()
    content = re.findall(contentRE, file)

for line in content:
 symbol = line[0]
 name = line[1]
 currency = line[2]
 exchange = line[3]
 country = line[4]
 type = line[5]
 if country == "Portugal":
  mercado = "Portugues"
 else:
  mercado = "Dow Jones"
 
 empresas.write("INSERT INTO EMPRESA " +
"(empresa_id,nome,categoria,website,localizacao,mercado_codigo) " +
"VALUES(\'" + symbol + "\',\'" + name + "\',\'" + type + "\',\'" + "webSite" + "\',\'" + country + "\',\'" + mercado +"\');\n")

content2RE = re.compile(
    r'{.+\n"symbol":"(.+)"\n"name".+\n"exchange".+\n"currency".+\n"datetime":"(.+)"\n"open":"(.+)"\n"high":"(.+)"\n"low":"(.+)"\n')

with open("acoes.txt") as e:
 file = e.read()
 content2 = re.findall(content2RE, file)
 
for line in content2:
 symbol = line[0]
 datetime = line[1]
 avg = line[2]
 high = line[3]
 low = line[4]
 acoes.write("INSERT INTO Acao " +
  "(codigo,hora,low,high,avg,empresa_id) " +
   "VALUES(\'" + symbol + "\',\'" + datetime + "\',\'" + low + "\',\'" + high + "\',\'" + avg + "\',\'" + symbol + "\');\n")

