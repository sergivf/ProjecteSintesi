<?xml version="1.0" encoding="utf-8"?>
	<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">

	  <xsl:output method="xml" indent="yes"/>      
	  <xsl:key name="groups" match="/DocumentElement/CLIENTS" use="CODIMUNICIPI" />

	  <xsl:template match="/DocumentElement">
	    <xsl:apply-templates select="CLIENTS[generate-id() = generate-id(key('groups', CODIMUNICIPI)[1])]"/>
	  </xsl:template>
	  <xsl:template match="CLIENTS">
		<h1><xsl:value-of select="CODIMUNICIPI"/></h1>
		<table id="{CODIMUNICIPI}" align="center" border="solid 0.1mm black" bgcolor="e0e0e0">
			<tr class="heading">
                            <th>CODI</th>
                            <th>NIF</th>
                            <th>NOM</th>
							<th>ADREÇA</th>
							<th>CODIPROVINCIA</th>
							<th>CODIMUNICIPI</th>
							<th>TELEFON</th>
							<th>FAX</th>
							<th>EMAIL</th>
							<th>BANCCC</th>
							<th>FORMADEPAGAMENT</th>
			</tr>
			<xsl:for-each select="key('groups', CODIMUNICIPI)">
		        <tr>
		          <td><xsl:value-of select="CODI"/></td>
		          <td><xsl:value-of select="NIF"/></td>
		          <td><xsl:value-of select="NOM"/></td>
  		          <td><xsl:value-of select="ADREÇA"/></td>
		          <td><xsl:value-of select="CODIPROVINCIA"/></td>
		          <td><xsl:value-of select="CODIMUNICIPI"/></td>
		          <td><xsl:value-of select="TELEFON"/></td>
		          <td><xsl:value-of select="FAX"/></td>
		          <td><xsl:value-of select="EMAIL"/></td>
  		          <td><xsl:value-of select="BANCCC"/></td>
		          <td><xsl:value-of select="FORMADEPAGAMENT"/></td>
		        </tr>
     		</xsl:for-each>
    	</table>
  	</xsl:template>
</xsl:stylesheet>