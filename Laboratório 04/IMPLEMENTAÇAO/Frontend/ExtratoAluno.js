//recupera do localStorage o aluno
let idAluno = JSON.parse(localStorage.getItem('userAluno'));

function imprimeExtratoAluno() {

  let extratoAluno = ''.concat('https://localhost:44372/api/extrato/extratoConta', '/', idAluno.contaId);
  console.log(extratoAluno);

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
      <td>${data[i].transacaoType  ? "ENVIADO" : "RECEBIDO"} </td>
`;

      };
      // Preencher a DIV com o texto HTML

      tela.innerHTML = strHtml;

    })
}
imprimeExtratoAluno();