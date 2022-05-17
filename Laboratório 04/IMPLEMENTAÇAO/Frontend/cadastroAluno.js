const baseURL = `https://localhost:44372/api/aluno`;
const baseURLInstituicao = `https://localhost:44372/api/instituicaoEnsino`;
let idUpdate;
let idInstituicao;

/* Mostrar instituições */

function imprimeInstitucao() {
  console.log("entrei");
  fetch(baseURLInstituicao, {
    
  }).then(result => result.json())
    .then((data) => {
 
      let tela = document.getElementById('instituicaoEnsino');
      let strHtml = "";
      console.log(data);
      // Montar texto HTML dos módulos
      for (i = 0; i < data.length; i++) {
        console.log(data);
        strHtml += `
        <option value="${data[i].id}">${data[i].nome}</option>
    `;
      };
 
      // Preencher a DIV com o texto HTML
      tela.innerHTML = strHtml;
    })
 }



/***
 * Início - Inclusão de novo aluno na base de dados.
 */
 const saveProviderAluno = (data) => {
  const renamedData = {
    nome: data.nome,
    email: data.email,
    cpf: data.cpf,
    rg:data.rg,
    endereco: data.endereco,
    instituicaoEnsinoId: data.instituicaoEnsino,
    curso: data.curso,
    senha: data.senha,
  }
  console.log("->" + renamedData);
  const xhr = new XMLHttpRequest();

  xhr.open('POST', 'https://localhost:44372/api/aluno', true);
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
  imprimeDados();
}



/***
* Imprime na tela os alunos já cadastrados.
*/
function imprimeDados() {
 fetch(baseURL, {
   
 }).then(result => result.json())
   .then((data) => {

     let tela = document.getElementById('content');
     let strHtml = "";
     console.log(data);
     // Montar texto HTML dos módulos
     for (i = 0; i < data.length; i++) {

       strHtml += `
       <tr>
       <td>${data[i].nome}</td>
       <td>${data[i].email}</td>
       <td>${data[i].cpf}</td>
       <td>${data[i].rg}</td>
       <td>${data[i].endereco}</td>
       <td>${data[i].instituicaoEnsinoId}</td>
       <td>${data[i].curso}</td>
       <td>
       <button type="button" id="btn_editar" onclick="editar(${data[i].id})" data-toggle="modal"
       data-target="modal" class="btn button green">Editar</button>
     <button type="button" id="btn_excluir" onclick="deletaAluno(${data[i].id})"
       class="btn button red">Excluir</button>
       </td>
       </tr>
   `;
     };

     // Preencher a DIV com o texto HTML
     tela.innerHTML = strHtml;
   })
   
}

/* Chama formulário novo aluno */

const formAluno = {

  getValue() {
    return {
        nome: document.getElementById('nome').value,
        email: document.getElementById('email').value,
        cpf: document.getElementById('CPF').value,
        rg: document.getElementById('RG').value,
        endereco: document.getElementById('endereco').value,
        instituicaoEnsinoId: document.getElementById('instituicaoEnsino').value,
        curso: document.getElementById('curso').value,
        senha: document.getElementById('senha').value

    }
  },

 

  formatProvider() {
    let { nome } = formAluno.getValue()
    let { email } = formAluno.getValue()
    let { cpf } = formAluno.getValue()
    let { rg } = formAluno.getValue()
    let { endereco } = formAluno.getValue()
    let { instituicaoEnsino } = formAluno.getValue()
    let { curso } = formAluno.getValue()
    let { senha } = formAluno.getValue()
    return {
      nome, email, cpf, rg, endereco, instituicaoEnsino, curso, senha
    }
  },

  clearProvider() {
    formAluno.nome.value = ""
    formAluno.email.value = ""
    formAluno.cpf.value = ""
    formAluno.rg.value = ""
    formAluno.endereco.value = ""
    formAluno.instituicaoEnsino.value = ""
    formAluno.curso.value = ""
    formAluno.senha.value = ""
  },

  submit(event) {
    console.log("entrei");
    event.preventDefault()
    try {
      const SaveProviderAluno = formAluno.formatProvider()
      console.log("entrei1");
      console.log(SaveProviderAluno);
      console.log("entrei2");
      saveProviderAluno(SaveProviderAluno);
      console.log("entrei3");
    } catch (error) {
      alert(error.message)
    }
  }
}

/*Exclusão de Aluno*/
function deletaAluno(id) {

  console.log("id->", id);
  var urlDelete = ''.concat(baseURL, '/', id);
  console.log("url->", urlDelete);

  fetch(urlDelete, {
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json',
    },
    method: 'delete', 
  }).then(function (res) {
    console.log("reposta delete->", res)
    window.location.reload();
  })
    .catch(function (res) { console.log("reposta delete->", res) })
}


imprimeDados();


/**
 * Função para editar o cadastro do Aluno. O modal é preenchidos com os dados já cadastrados.
 

 function editar(id) {
  console.log("Entrou..... ->");
  console.log("Id selecionado ->", id);
  fetch(baseURL, {
    
  }).then(result => result.json())
    .then((data) => {
     
      for (i = 0; i < data.length; i++) {
        if (data[i].id == id) {
          console.log(data[i]);
          $("nome").val(data[i].nome);
          $("email").val(data[i].email);
          $("CPF").val(data[i].cpf);
          $("RG").val(data[i].rg);
          $("endereco").val(data[i].endereco);
          $("instituicaoEnsino").val(data[i].instituicaoEnsinoId);
          $("curso").val(data[i].curso);
          $("senha").val(data[i].senha);
         
        }
      }
    })
  idUpdate = id;
  //openModal()
}

/*
 Chama formulário edita aluno 

const formAlunoUpdate = {
  getValue() {
    return {
        nome: document.getElementById('editNome').value,
        email: document.getElementById('editEmail').value,
        cpf: document.getElementById('editCPF').value,
        rg: document.getElementById('editRG').value,
        endereco: document.getElementById('editEndereco').value,
        instituicaoEnsino: document.getElementById('editInstituicaoEnsino').value,
        curso: document.getElementById('editCurso').value,
        senha: document.getElementById('editSenha').value,
    }
  },



  formatProvider() {
    let { nome } = formAlunoUpdate.getValue()
    let { email } = formAlunoUpdate.getValue()
    let { cpf } = formAlunoUpdate.getValue()
    let { rg } = formAlunoUpdate.getValue()
    let { endereco } = formAlunoUpdate.getValue()
    let { instituicaoEnsino } = formAlunoUpdate.getValue()
    let { curso } = formAlunoUpdate.getValue()
    let { senha } = formAlunoUpdate.getValue()
    return {
      nome, email, cpf, rg, endereco, instituicaoEnsino, curso, senha
    }
  },

  clearProvider() {
    formAlunoUpdate.nome.value = ""
    formAlunoUpdate.email.value = ""
    formAlunoUpdate.cpf.value = ""
    formAlunoUpdate.rg.value = ""
    formAlunoUpdate.endereco.value = ""
    formAlunoUpdate.instituicaoEnsino.value = ""
    formAlunoUpdate.curso.value = ""
    formAlunoUpdate.senha.value = ""
  },

  submit(event) {
    console.log("entrooou")
    event.preventDefault()
    try {
      formAlunoUpdate.validateFields()
      const SaveProviderUpdate = formAlunoUpdate.formatProvider()
      saveProviderUpdate(SaveProviderUpdate)
    } catch (error) {
      alert(error.message)
    }
  }
}


 * Início - Atualização dos dados do aluno já cadastrado.

 const saveProviderUpdate = (data) => {
  const renamedDataUpdate = {
    id: idUpdate,
    nome: data.nome,
    email: data.email,
    cpf: data.cpf,
    rg:data.rg,
    endereco: data.endereco,
    instituicaoEnsino: data.instituicaoEnsinoId,
    curso: data.curso,
    senha: data.senha,
  }
  const xhrUpdate = new XMLHttpRequest();

  xhrUpdate.open('PUT', 'https://localhost:44372/api/aluno', true);
  xhrUpdate.setRequestHeader("Content-type", "application/json");

  xhrUpdate.onreadystatechange = () => {
    if (xhrUpdate.readyState == 4) {
      if (xhrUpdate.status == 200) {
        console.log(xhrUpdate.responseText);
        window.location.reload();
      }
     
    }
  }
  console.log("dados->>", renamedDataUpdate);
  xhrUpdate.send(JSON.stringify(renamedDataUpdate));
}

*/

imprimeInstitucao();

