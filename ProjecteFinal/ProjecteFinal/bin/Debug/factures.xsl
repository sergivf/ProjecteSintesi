<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <html>
            <head>
                <title>Listat de factures</title>
            </head>
            <body>
				<h1>Logotip de l'empresa</h1>
				<table align="center" border="solid 0.1mm black" bgcolor="e0e0e0">
					<tr>
						<th>Descripcio</th>
						<th>Quantitat venuda</th>
						<th>Preu venda</th>
						<th>Descompte</th>
						<th>Preu final de línia</th>
					</tr>
					<xsl:for-each select="Factures/LiniaFactura">
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