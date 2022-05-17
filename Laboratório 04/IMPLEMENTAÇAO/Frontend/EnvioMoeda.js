const baseURL = `https://localhost:44372/api/aluno`;
const baseURLprofessor = `https://localhost:44372/api/professor`;
let alunosCadastrados;
let alunoSelecionado;


function imprimeAluno() {

  console.log("entrei1");
    fetch(baseURL, {
      
    }).then(result => result.json())
      .then((data) => {
   
        let tela = document.getElementById('selectAluno');
        let strHtml = "";
        console.log(data);
        alunosCadastrados = data;
        // Montar texto HTML dos módulos
        for (i = 0; i < data.length; i++) {
  
          strHtml += `
          <option value="${data[i].id}">${data[i].nome}</option>
      `;
        };
        // Preencher a DIV com o texto HTML
        tela.innerHTML = strHtml;
      })
   }

   imprimeAluno();


const form = {
    getValue() {
      return {
          aluno: document.getElementById('selectAluno').value,
          valorTranferencia: document.getElementById('valorTransf').value,
      }
    },
  

    formatProvider() {
      let { aluno } = form.getValue()
      let { valorTranferencia } = form.getValue()
      
      return {
        aluno, valorTranferencia
      }
    },
  
    clearProvider() {
      form.aluno.value = ""
      form.valorTranferencia.value = ""
    },
  
    submit(event) {
      console.log("entrei");
      event.preventDefault()
      try {
        const SaveProvider = form.formatProvider()
        console.log("entrei1");
        console.log(SaveProvider);
        saveProvider(SaveProvider);
      } catch (error) {
        alert(error.message)
      }
    }
  }


  const saveProvider = (data) => {
    

    for(i = 0; i < alunosCadastrados.length; i++){

      if(data.nome == alunosCadastrados[i].nome){
        alunoSelecionado = alunosCadastrados[i];
      }
    };

    let contaProfessorId = 1;
    let contaAlunoId = alunoSelecionado.contaId ;

    const renamedData = {
      valor: data.valorTranferencia,
      contaAlunoId: contaAlunoId,
      contaProfessorId: contaProfessorId,
    };

    console.log(renamedData);
    const xhr = new XMLHttpRequest();
  
    xhr.open('POST', 'https://localhost:44372/api/extrato', true);
    xhr.setRequestHeader("Content-type", "application/json");
    xhr.onreadystatechange = () => {
      if (xhr.readyState == 4) {
        if (xhr.status == 200) {
          console.log(xhr.responseText);
          window.location.reload();
        }
      }
    }
  
    console.log("dados->", renamedData);
    xhr.send(JSON.stringify(renamedData));
  }


  //----------------------------------------------------------- Extrato


  function imprimeExtrato() {
    fetch(baseURLprofessor, {
      
    }).then(result => result.json())
      .then((data) => {
   
        let tela = document.getElementById('content');
        let strHtml = "";
        console.log(data);

        let extratoProfessor = `https://localhost:44372/api/extrato/extratoConta/1`;
        

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