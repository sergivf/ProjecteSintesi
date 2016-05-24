<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <html>
            <head>
                <title>LLISTAT DELS 5 MILLORS COMPRADORS</title>
            </head>
            <body>
                <h1>
                    <table align="center" border="solid 0.1mm black" bgcolor="e0e0e0">
                        <tr>
                            <th>CODI</th>
                            <th>DESCRIPCIO</th>
                            <th>QUANTITATSTOCK</th>
							<th>PCOST</th>
							<th>PVENDA</th>
							<th>DESCOMPTE</th>
                        </tr>
						<xsl:for-each select="DocumentElement/ARTICLES">
							<tr>
								<td><xsl:value-of select="CODI"/></td>
								<td><xsl:value-of select="DESCRIPCIO"/></td>
								<td><xsl:value-of select="QUANTITATSTOCK"/></td>
								<td><xsl:value-of select="PCOST"/></td>
								<td><xsl:value-of select="PVENDA"/></td>
								<td><xsl:value-of select="DESCOMPTE"/></td>
							</tr>
						</xsl:for-each>
					</table>
				</h1>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>