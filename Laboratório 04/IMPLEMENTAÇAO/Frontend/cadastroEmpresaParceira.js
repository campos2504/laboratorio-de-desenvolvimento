const baseURL = `https://localhost:44372/api/empresaParceira`;
let idUpdate;
let idInstituicao;


/***
 * Início - Inclusão de novo EmpresaParceira na base de dados.
 */
 const saveProviderEmpresaParceira = (data) => {
  const renamedData = {
    nome: data.nome,
    cnpj: data.cnpj,
    email: data.email,
    senha: data.senha,
  }
  console.log("->" + renamedData);
  const xhr = new XMLHttpRequest();

  xhr.open('POST', 'https://localhost:44372/api/empresaParceira', true);
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
* Imprime na tela os EmpresaParceiras já cadastrados.
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
       <td>${data[i].cnpj}</td>
       <td>${data[i].email}</td>
       <td>
       <button type="button" id="btn_editar" onclick="editar(${data[i].id})" data-toggle="modal"
       data-target="#modalEditaEmpresa" class="btn button green">Editar</button>
     <button type="button" id="btn_excluir" onclick="deletaEmpresaParceira(${data[i].id})"
       class="btn button red">Excluir</button>
       </td>
       </tr>
   `;
     };

     // Preencher a DIV com o texto HTML
     tela.innerHTML = strHtml;
   })
   
}

/* Chama formulário novo EmpresaParceira */

const formEmpresaParceira = {

  getValue() {
    return {
        nome: document.getElementById('nome').value,
        cnpj: document.getElementById('cnpj').value,
        email: document.getElementById('email').value,
        senha: document.getElementById('senha').value
    }
  },

  formatProvider() {
    let { nome } = formEmpresaParceira.getValue()
    let { cnpj } = formEmpresaParceira.getValue()
    let { email } = formEmpresaParceira.getValue()
    let { senha } = formEmpresaParceira.getValue()
    return {
      nome, cnpj, email, senha
    }
  },

  clearProvider() {
    formEmpresaParceira.nome.value = ""
    formEmpresaParceira.cnpj.value = ""
    formEmpresaParceira.email.value = ""
    formEmpresaParceira.senha.value = ""
  },

  submit(event) {
    console.log("entrei");
    event.preventDefault()
    try {
      const SaveProviderEmpresaParceira = formEmpresaParceira.formatProvider()
      console.log("entrei1");
      console.log(SaveProviderEmpresaParceira);
      console.log("entrei2");
      saveProviderEmpresaParceira(SaveProviderEmpresaParceira);
      console.log("entrei3");
    } catch (error) {
      alert(error.message)
    }
  }
}

/*Exclusão de EmpresaParceira*/
function deletaEmpresaParceira(id) {

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


function editar(id) {
  console.log("Entrou..... ->");
  console.log("Id selecionado ->", id);
  fetch(baseURL, {
    
  }).then(result => result.json())
    .then((data) => {
     
      for (i = 0; i < data.length; i++) {
        if (data[i].id == id) {
          console.log(data[i]);
          $("#EditNome").val(data[i].nome);
          $("#EditCnpj").val(data[i].cnpj);
          $("#EditEmail").val(data[i].email);
          $("#EditSenha").val(data[i].senha);
         
        }
      }
    })
  idUpdate = id;
  //openModal()
}


/**
 * Função para editar o cadastro do EmpresaParceira. O modal é preenchidos com os dados já cadastrados.
 */


const formEmpresaParceiraUpdate = {
  getValue() {
    return {
        nome: document.getElementById('EditNome').value,
        cnpj: document.getElementById('EditCnpj').value,
        email: document.getElementById('EditEmail').value,
        senha: document.getElementById('EditSenha').value,
    }
  },

  formatProvider() {
    let { nome } = formEmpresaParceiraUpdate.getValue()
    let { cnpj } = formEmpresaParceiraUpdate.getValue()
    let { email } = formEmpresaParceiraUpdate.getValue()
    let { senha } = formEmpresaParceiraUpdate.getValue()
    return {
      nome, cnpj, email, senha
    }
  },

  clearProvider() {
    formEmpresaParceiraUpdate.nome.value = ""
    formEmpresaParceiraUpdate.cnpj.value = ""
    formEmpresaParceiraUpdate.email.value = ""
    formEmpresaParceiraUpdate.senha.value = ""
  },

  submit(event) {
    console.log("entrooouUpdate")
    event.preventDefault()
    try {
      const SaveProviderUpdate = formEmpresaParceiraUpdate.formatProvider()
      saveProviderUpdate(SaveProviderUpdate)
    } catch (error) {
      alert(error.message)
    }
  }
}


 /* Início - Atualização dos dados do EmpresaParceira já cadastrado.*/

 const saveProviderUpdate = (data) => {
 
  const renamedDataUpdate = {
    id: idUpdate,
    nome: data.nome,
    cnpj: data.cnpj,
    email: data.email,
    senha: data.senha,
  }
  const xhrUpdate = new XMLHttpRequest();

  xhrUpdate.open('PUT', 'https://localhost:44372/api/empresaParceira', true);
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
  imprimeDados();
}




