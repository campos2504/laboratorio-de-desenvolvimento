let imagemFormModulo;
let imagemFormModuloUpdate;
let imagemNomeModulo;
let imagemNomeModuloUpdate;
let imageBase64Modulo;
let imageBase64ModuloUpdate;
let binaryString;
let binaryStringUpdate;
let idUpdate;
const baseURL = `https://localhost:44372/api/vantagem`;

/***
 * Imprime na tela os módulos já cadastrados.
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
        <div class="col-12 col-md-4 my-2">
          <div class="position-relative">            
                <img class="card-img-fluid" src="${data[i].imagemSrc}">                
                <div class="card-img-overlay nomeModulo">
                <div class="botoesCard">
                  <button type="button" style="" id="btn_editar" onclick="editar(${data[i].id})" data-toggle="modal"
                    data-target="#modalEdicaoModulo" class="btn btn-light btn-circle btn-sm">
                    <svg width="2em" height="2em" viewBox="0 0 16 16" class="bi bi-pencil editar-excluir"
                        fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                        <path fill-rule="evenodd"
                            d="M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 .708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168l10-10zM11.207 2.5L13.5 4.793 14.793 3.5 12.5 1.207 11.207 2.5zm1.586 3L10.5 3.207 4 9.707V10h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.293l6.5-6.5zm-9.761 5.175l-.106.106-1.528 3.821 3.821-1.528.106-.106A.5.5 0 0 1 5 12.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.468-.325z" />
                    </svg>
                  </button>
                  <button type="button" style="" id="btn_excluir" onclick="deletaModulo(${data[i].id})"
                    class="btn btn-light btn-circle btn-sm">
                    <svg width="3em" height="3em" viewBox="0 0 16 16" class="bi bi-x editar-excluir"
                        fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                        <path fill-rule="evenodd"
                            d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z" />
                    </svg>
                  </button>
                </div>
                  <div class="card-text">
                  <a href="" onclick="selecionarModulo(${data[i].id})">
                    <h1 class="linkModulo">${data[i].descricao}</h1></a>
                    <h1 class="linkModulo">${data[i].valor}</h1></a>
                  </div>
                </div>            
          </div>
        </div>`;
      };

      // Preencher a DIV com o texto HTML
      tela.innerHTML = strHtml;
    })
}

/**
 * Função para editar o cadastro do módulo. O modal é preenchidos com os dados já cadastrados.
 */


  function editar(id) {
    console.log("Entrou..... ->");
    console.log("Id selecionado ->", id);
    fetch(baseURL, {
    }).then(result => result.json())
      .then((data) => {
        console.log("imagem ->", data);
        for (i = 0; i < data.length; i++) {
          if (data[i].id == id) {
            console.log(data[i]);
            $("#editDescricaoModulo").val(data[i].nomeModulo);
            document.getElementById('editFotoModulo').src = data[i].imagemSrc;
          }
        }
      })
    idUpdate = id;
  }


/**
 * 
 * @param {*} id Função para deletar o módulo, conforme ID selecionado
 */
function deletaModulo(id) {

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


/**
 * Início - Processar o upload da foto, transformando em uma base de 64.
 */
function checkfilesModulo(event) {
  let fileName = event.target.value;
  let ext = fileName.substring(fileName.lastIndexOf('.') + 1);

  if (ext == "jpeg" || ext == "png" || ext == "jpg") {
    return true;
  }
  else {
    return false;
  }
}

var loaderFileModulo = function (event) {
  console.log(event);
  var readerModulo = new FileReader();

  if (!checkfilesModulo(event)) {
    alert("Não foi possível carregar a imagem, formato não suportado!")
    return false;
  }

  readerModulo.onload = function () {
    var outputModulo = document.getElementById("newModulo");
    outputModulo.style.display = "block";
    outputModulo.style.backgroundImage = "url(" + readerModulo.result + ")";
  }
  readerModulo.readAsDataURL(event.target.files[0]);

  uploadModulo(event.target.files[0]);
};


function uploadModulo(file) {

  imagemFormModulo = file;
  imagemNomeModulo = file.name;

  var readerModulo = new FileReader();
  readerModulo.onload = this.manipularReader.bind(this);
  readerModulo.readAsBinaryString(file);
};

function manipularReader(readerEvt) {
  binaryString = readerEvt.target.result;
  imageBase64Modulo = btoa(binaryString);
};

/***
 * Fim - Processar o upload da foto, transformando em uma base de 64.
 */


/***
 * Início - Inclusão de novo módulo na base de dados.
 */
const saveProviderModulo = (data) => {
    let valor = parseInt(data.valorVantagem);
  const renamedData = {
    descricao: data.descricaoModulo,
    imagem: imagemNomeModulo,
    imagemUpload: imageBase64Modulo,
    valor: valor,
    empresaParceiraId: 2
  }
  const xhr = new XMLHttpRequest();

  xhr.open('POST', 'https://localhost:44372/api/vantagem', true);
  xhr.setRequestHeader("Content-type", "application/json");
  xhr.onreadystatechange = () => {
    if (xhr.readyState == 4) {
      if (xhr.status == 200) {
        console.log(xhr.responseText);
        window.location.reload();
      }
      else {
        let log3 = xhr.responseText;
        let log4 = JSON.parse(log3); 
        
        if(log4.success == false){
          alert(log4.errors + " . " + "Favor inserir a foto novamente!");
        }else{
          alert("Verifique se foram informados apenas letras e espaços no nome do módulo!")
        }  
      }
    }
  }

  console.log("dados->", renamedData);
  xhr.send(JSON.stringify(renamedData));
  imprimeDados();
}

const formModulo = {
  getValue() {
    return {
      descricaoModulo: document.querySelector('#descricaoModulo').value,
      valorVantagem: document.querySelector('#valorVantagem').value,
    }
  },

  validateFields() {
    const { descricaoModulo, valorVantagem } = formModulo.getValue()
    if (descricaoModulo.trim() === "" || valorVantagem === "") {
      throw new Error("Por favor, preencha todos os campos")
    }
  },

  formatProvider() {
    let { descricaoModulo, valorVantagem } = formModulo.getValue()
    return {
      descricaoModulo, valorVantagem
    }
  },

  clearProvider() {
    formModulo.descricaoModulo.value = ""
    formModulo.valorVantagem.value = ""
  },

  submit(event) {
    event.preventDefault()
    try {
      formModulo.validateFields()
      const SaveProviderModulo = formModulo.formatProvider()
      saveProviderModulo(SaveProviderModulo)
    } catch (error) {
      alert(error.message)
    }
  }
}

/*$('#modalInclusaoModulo').modal('hide');*/

imprimeDados();

/***
 * Fim - Inclusão de novo módulo na base de dados.
 */



const formModuloUpdate = {
  getValue() {
    return {
      descricaoModuloUpdate: document.querySelector('#editDescricaoModulo').value,
      valorVantagemUpdate: document.querySelector('#editValorVantagem').value,
    }
  },

  validateFields() {
    const { descricaoModuloUpdate, valorVantagemUpdate } = formModuloUpdate.getValue()
    if (descricaoModuloUpdate.trim() === "" || valorVantagemUpdate === "") {
      throw new Error("Por favor, preencha todos os campos")
    }
  },

  formatProvider() {
    let { descricaoModuloUpdate, valorVantagemUpdate } = formModuloUpdate.getValue()
    return {
      descricaoModuloUpdate, valorVantagemUpdate
    }
  },

  clearProvider() {
    formModuloUpdate.descricaoModuloUpdate.value = ""
    formModuloUpdate.valorVantagemUpdate.value = ""
  },

  submit(event) {
    event.preventDefault()
    try {
      formModuloUpdate.validateFields()
      const SaveProviderModuloUpdate = formModuloUpdate.formatProvider()
      saveProviderModuloUpdate(SaveProviderModuloUpdate)
    } catch (error) {
      alert(error.message)
    }
  }
}


/***
 * Início - Atualização dos dados de módulo já cadastrado.
 */
const saveProviderModuloUpdate = (data) => {
    let valor = parseInt(data.valorVantagemUpdate);
  const renamedDataUpdate = {
    id: idUpdate,
    descricao: data.descricaoModuloUpdate,
    imagem: imagemNomeModuloUpdate,
    imagemUpload: imageBase64ModuloUpdate,
    valor: valor,
    empresaParceiraId: 2
  }
  const xhrUpdate = new XMLHttpRequest();

  xhrUpdate.open('PUT', 'https://localhost:44372/api/vantagem', true);
  xhrUpdate.setRequestHeader("Content-type", "application/json");

  xhrUpdate.onreadystatechange = () => {
    if (xhrUpdate.readyState == 4) {
      if (xhrUpdate.status == 200) {
        console.log(xhrUpdate.responseText);
        window.location.reload();
      }
      else {
        let log = xhrUpdate.responseText;
        let log2 = JSON.parse(log); 
        
        if(log2.success == false){
          alert(log2.errors + " . " + "Favor inserir a foto novamente!");
        }else{
          alert("Verifique se foram informados apenas letras e espaços no nome do módulo!")
        }             
      }
    }
  }

  console.log("dados->", renamedDataUpdate);
  xhrUpdate.send(JSON.stringify(renamedDataUpdate));
  imprimeDados();
}


/*Processar upload foto módulo - Update*/
function checkfilesModuloUpdate(event) {
  let fileName = event.target.value;
  let ext = fileName.substring(fileName.lastIndexOf('.') + 1);

  if (ext == "jpeg" || ext == "png" || ext == "jpg") {
    return true;
  }
  else {
    return false;
  }
}

var loaderFileModuloUpdate = function (event) {
  var readerModuloUpdate = new FileReader();

  if (!checkfilesModuloUpdate(event)) {
    alert("Não foi possível carregar a imagem, formato não suportado!")
    return false;
  }

  readerModuloUpdate.onload = function () {
    var outputModuloUpdate = document.getElementById("newModuloUpdate");
    outputModuloUpdate.style.display = "block";
    outputModuloUpdate.style.backgroundImage = "url(" + readerModuloUpdate.result + ")";
  }
  readerModuloUpdate.readAsDataURL(event.target.files[0]);

  uploadModuloUpdate(event.target.files[0]);
};


function uploadModuloUpdate(file) {

  imagemFormModuloUpdate = file;
  imagemNomeModuloUpdate = file.name;

  var readerModuloUpdate = new FileReader();
  readerModuloUpdate.onload = this.manipularReaderUpdate.bind(this);
  readerModuloUpdate.readAsBinaryString(file);
};

function manipularReaderUpdate(readerEvt) {
  binaryStringUpdate = readerEvt.target.result;
  imageBase64ModuloUpdate = btoa(binaryStringUpdate);
};

/***
 * Fim - Atualização dos dados de módulo já cadastrado.
 */


/**
 * Salvar no localStorage o id do módulo escolhido.
 */
function selecionarModulo(event) {

  console.log(event);

  if (event) {
    localStorage.setItem('vantagemEscolhida', JSON.stringify({ event }));
  };
};