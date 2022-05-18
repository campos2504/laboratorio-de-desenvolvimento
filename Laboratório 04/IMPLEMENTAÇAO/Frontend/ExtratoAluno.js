function imprimeExtratoAluno() {

  let extratoAluno = `https://localhost:44372/api/extrato/extratoConta/10016`;

  fetch(extratoAluno, {
  }).then(result => result.json())

    .then((data) => {
      console.log(data);
      let tela = document.getElementById('content');

      let strHtml = "";
      // Montar texto HTML dos módulos

      for (i = 0; i < data.length; i++) {
        strHtml += `

    <tr>
     <td>${data[i].valor}</td>
      <td>${data[i].transacaoType}</td>
`;

      };
      // Preencher a DIV com o texto HTML

      tela.innerHTML = strHtml;

    })
}
imprimeExtratoAluno();