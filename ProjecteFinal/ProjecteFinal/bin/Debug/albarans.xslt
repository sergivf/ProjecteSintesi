<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
    <xsl:template match="/">
        <html>
            <head>
                <title>Listat d'albarans</title>
            </head>
            <body>
				<h1>Data del llistat : <xsl:value-of select="current-dateTime()" /></h1>
				<hr/>
				<h3>Logotip de l'empresa : </h3>
				<h3>Nom de l'empresa : <xsl:value-of select="Albarans/Empresa/Nom"/></h3>
				<h3>Adreça de l'empresa : <xsl:value-of select="Albarans/Empresa/Adreça"/></h3>
				<h3>NIF de l'empresa : <xsl:value-of select="Albarans/Empresa/NIF"/></h3>
				<h3>Telèfon de l'empresa : <xsl:value-of select="Albarans/Empresa/Telefon"/></h3>
				<h3>Fax de l'empresa : <xsl:value-of select="Albarans/Empresa/Fax"/></h3>
				
				<hr/>
				<hr/>
				
				<h3>Nom del client : <xsl:value-of select="Albarans/CabAlbara/Nom"/></h3>
				<h3>Adreça del client : <xsl:value-of select="Albarans/CabAlbara/Direccio"/></h3>
				<h3>NIF del client : <xsl:value-of select="Albarans/CabAlbara/NIF"/></h3>
				<h3>Data de l'albarà : <xsl:value-of select="Albarans/CabAlbara/DataAlbara"/></h3>
				<h3>Número de l'albarà : <xsl:value-of select="Albarans/CabAlbara/NAlbara"/></h3>
				
				<table align="center" border="solid 0.1mm black" bgcolor="e0e0e0">
					<tr>
						<th>Descripcio</th>
						<th>Quantitat venuda</th>
						<th>Preu venda</th>
						<th>Descompte</th>
						<th>Preu final de línia</th>
					</tr>
					<xsl:for-each select="Albarans/LiniaAlbara">
						<tr>
							<td><xsl:value-of select="Descripcio"/></td>
							<td><xsl:value-of select="QuantitatVenuda"/></td>
							<td><xsl:value-of select="PreuVenda"/></td>
							<td><xsl:value-of select="Descompte"/></td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>