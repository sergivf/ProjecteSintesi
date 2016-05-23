<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <html>
            <head>
                <title>Listat d'albarans</title>
            </head>
            <body>
				<h1>Logotip de l'empresa</h1>
				<table align="center" border="solid 0.1mm black" bgcolor="e0e0e0">
					<tr>
						<th>Número albarà</th>
						<th>Codi article</th>
						<th>Descripció</th>
						<th>Quantitat venuda</th>
						<th>Preu venda</th>
					</tr>
					<xsl:for-each select="OracleDataSet/LINEASALBARA">
						<tr>
							<td><xsl:value-of select="NALBARA"/></td>
							<td><xsl:value-of select="CODIARTICLE"/></td>
							<td><xsl:value-of select="DESCRIPCIO"/></td>
							<td><xsl:value-of select="QUANTITATVENUDA"/></td>
							<td><xsl:value-of select="PREUVENDA"/></td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>