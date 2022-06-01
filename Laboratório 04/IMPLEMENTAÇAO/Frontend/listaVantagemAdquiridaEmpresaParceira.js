
function imprimeVantagensAdquiridasAlunos() {

    let url = ''.concat('https://localhost:44372/api/vantagemUser');

    fetch(url, {
    }).then(result => result.json())

        .then((data) => {
            console.log(data);
            let tela = document.getElementById('content');

            let strHtml = "";
            // Montar texto HTML dos módulos

            for (i = 0; i < data.length; i++) {
                
                strHtml += `
  
                <tr>
                    <td>${data[i].vantagem.descricao}</td>
                    <td>${data[i].vantagem.valor}</td>
                    <td>${data[i].codigoTroca}</td>
                </tr>
         `;
            };
            // Preencher a DIV com o texto HTML

            tela.innerHTML = strHtml;

        })
}
imprimeVantagensAdquiridasAlunos();
