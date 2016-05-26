<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <html>
            <head>
                <title>Listat de factures</title>
            </head>
            <body>
				<h1>Data del llistat : <xsl:value-of select="Factures/Empresa/DataLlistat"/></h1>
				<hr/>
				<h3>Logotip de l'empresa : </h3>
				<h3>Nom de l'empresa : <xsl:value-of select="Factures/Empresa/Nom"/></h3>
				<h3>Adreça de l'empresa : <xsl:value-of select="Factures/Empresa/Adreça"/></h3>
				<h3>NIF de l'empresa : <xsl:value-of select="Factures/Empresa/NIF"/></h3>
				<h3>Telèfon de l'empresa : <xsl:value-of select="Factures/Empresa/Telefon"/></h3>
				<h3>Fax de l'empresa : <xsl:value-of select="Factures/Empresa/Fax"/></h3>
				
				<hr/>
				<hr/>
				
				<h3>Nom del client : <xsl:value-of select="Factures/CabFactura/Nom"/></h3>
				<h3>Adreça del client : <xsl:value-of select="Factures/CabFactura/Direccio"/></h3>
				<h3>NIF del client : <xsl:value-of select="Factures/CabFactura/NIF"/></h3>
				<h3>Data de la factura : <xsl:value-of select="Factures/CabFactura/DataAlbara"/></h3>
				<h3>Número de la factura : <xsl:value-of select="Factures/CabFactura/NAlbara"/></h3>
				
				<table align="center" border="solid 0.1mm black" bgcolor="e0e0e0">
					<tr>
						<th>Descripció</th>
						<th>Quantitat venuda</th>
						<th>Preu venda</th>
						<th>Descompte</th>
						<th>Preu final de línia</th>
					</tr>
					<xsl:for-each select="Factures/LiniaFactura">
						<tr>
							<xsl:variable name="quantitatVenuda"><xsl:value-of select="QuantitatVenuda"/></xsl:variable>
							<xsl:variable name="preuVenda"><xsl:value-of select="PreuVenda"/></xsl:variable>
							<xsl:variable name="descompte"><xsl:value-of select="Descompte"/></xsl:variable>
							<xsl:variable name="preuFinal"><xsl:value-of select="($quantitatVenuda * $preuVenda) * (1 - ($descompte div 100))"/></xsl:variable>
							
							<td><xsl:value-of select="Descripcio"/></td>
							<td><xsl:value-of select="$quantitatVenuda"/></td>
							<td><xsl:value-of select="$preuVenda"/></td>
							<td><xsl:value-of select="$descompte"/></td>
							<td><xsl:value-of select="$preuFinal"/></td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>