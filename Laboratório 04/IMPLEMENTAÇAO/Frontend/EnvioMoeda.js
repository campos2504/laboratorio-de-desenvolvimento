const baseURL = `https://localhost:44372/api/aluno`;
const baseURLprofessor = `https://localhost:44372/api/professor`;
let alunosCadastrados;
let alunoSelecionado;

//recupera do localStorage o professor
let idProfessor = JSON.parse(localStorage.getItem('userProfessor'));

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
          if(data[i].instituicaoEnsinoId == idProfessor.instituicaoEnsinoId)
          strHtml += `
          <option value="${data[i].id}">${data[i].nome}</option>
      `;
        };
        // Preencher a DIV com o texto HTML
        tela.innerHTML = strHtml;
      })
   }

   imprimeAluno();


const formMoeda = {
    getValue() {
      return {
          aluno: document.getElementById('selectAluno').value,
          valorTranferencia: document.getElementById('valorTransf').value,
      }
    },
  

    formatProvider() {
      let { aluno } = formMoeda.getValue()
      let { valorTranferencia } = formMoeda.getValue()
      
      return {
        aluno, valorTranferencia
      }
    },
  
    clearProvider() {
      formMoeda.aluno.value = ""
      formMoeda.valorTranferencia.value = ""
    },
  
    submit(event) {
      event.preventDefault()
      try {
        const SaveProvider = formMoeda.formatProvider()
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
      if(data.aluno == alunosCadastrados[i].id){
        alunoSelecionado = alunosCadastrados[i];
      }
    };
    let contaProfessorId = idProfessor.id;
    let contaAlunoId = alunoSelecionado.contaId;
    console.log(contaAlunoId);

    let valorMoeda = parseInt(data.valorTranferencia);

    const renamedData = {
      valor: valorMoeda,
      contaAlunoId: contaAlunoId,
      contaProfessorId: contaProfessorId,
    };

    console.log(renamedData);
    const xhrMoeda = new XMLHttpRequest();
  
    xhrMoeda.open('POST', 'https://localhost:44372/api/extrato', true);
    xhrMoeda.setRequestHeader("Content-type", "application/json");
    xhrMoeda.onreadystatechange = () => {
      if (xhrMoeda.readyState == 4) {
        if (xhrMoeda.status == 200) {
          console.log(xhrMoeda.responseText);
          window.location.reload();
        }
      }
    }
  
    console.log("dados->", renamedData);
    xhrMoeda.send(JSON.stringify(renamedData));
  }


  //----------------------------------------------------------- Extrato


  function imprimeExtratoProfessor() {

    let extratoAluno = ''.concat('https://localhost:44372/api/extrato/extratoConta', '/', idProfessor.contaId);

    fetch(extratoAluno, {
    }).then(result => result.json())
  
      .then((data) => {
        console.log(data);
        document.getElementById('saldo').value = data[0].conta.saldo;
        let tela = document.getElementById('content');
  
        let strHtml = "";
        // Montar texto HTML dos módulos
  
        for (i = 0; i < data.length; i++) {
          strHtml += `
  
        <tr>
        <td>${data[i].valor}</td>
        <td>${data[0].transacaoType ? "ENVIADO" : "RECEBIDO"}</td>
  `;

        };
        // Preencher a DIV com o texto HTML  
        tela.innerHTML = strHtml;
  
      })
  }
  imprimeExtratoProfessor();