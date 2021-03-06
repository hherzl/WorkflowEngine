<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <h2>Execution Results</h2>
    <table>
      <xsl:for-each select="ExecutionSummary/Results/ExecutionResult">
        <tr>
          <td>
            <xsl:value-of select="WorkflowName"/>
          </td>
          <td>
            <xsl:value-of select="Succeeded"/>
          </td>
        </tr>
      </xsl:for-each>
    </table>
  </xsl:template>
</xsl:stylesheet>
