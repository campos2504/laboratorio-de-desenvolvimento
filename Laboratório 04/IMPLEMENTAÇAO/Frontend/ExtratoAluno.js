



 function imprimeExtrato() {
  fetch(baseURL, {
    
  }).then(result => result.json())
    .then((data) => {
 
      let tela = document.getElementById('content');
      let strHtml = "";
      console.log(data);


      let extratoProfessor = `https://localhost:44372/api/extrato/extratoConta/`;
      

      // Montar texto HTML dos módulos
      for (i = 0; i < data.length; i++) {
 
        strHtml += `
        <tr>
        <td>${data[i].nome}</td>
        <td>${data[i].valor}</td>
        <td>${data[i].TransacaoType}</td>
    `;
      };
 
      // Preencher a DIV com o texto HTML
      tela.innerHTML = strHtml;
    })
    
 }

   imprimeExtrato();