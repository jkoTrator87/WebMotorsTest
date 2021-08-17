const cep = document.querySelector("#cep")
const areaAnuncios = document.querySelector("#areaAnuncios")
const marca = document.querySelector("#marca")
const modelo = document.querySelector("#modelo")
const versao = document.querySelector("#versao")
const ano = document.querySelector("#ano")
const km = document.querySelector("#km")
const obs = document.querySelector("#obs")
const options = { method: 'GET', mode: 'cors', cache: 'default' }
const urlMarcas = `https://desafioonline.webmotors.com.br/api/OnlineChallenge/Make`;
const urlAnuncios = `https://desafioonline.webmotors.com.br/api/OnlineChallenge/Vehicles?Page=1`;

// Executado ao terminar o Load da Página    
window.onload = function Load() {
    loadMarcas();
}

// CarregaAnuncios já cadastrados
function loadAnuncios() {
    fetch(urlAnuncios, options)
        .then(response => {
            response.json()
                .then(data => popularAnuncios(data))
        })
        .catch(e => console.log('Error: ' + e.message))
}

// Carrega o combo de Marcas
function loadMarcas() {
    fetch(urlMarcas, options)
        .then(response => { response.json()
            .then(data => popularMarca(data))
        })
        .catch(e => console.log('Error: ' + e.message))
};

// Executado quando há interação com o combo de Marcas
marca.addEventListener("change", () =>{
    let marcaId = marca.value
    fetch(`https://desafioonline.webmotors.com.br/api/OnlineChallenge/Model?MakeID=${marcaId}`, options)
        .then(response => { response.json()
            .then(data => popularModelo(data))
        })
        .catch(e => console.log('Error: ' + e.message))
})

// Executado quando há interação com o combo de Modelos
modelo.addEventListener("change", () => {
    let modeloId = modelo.value
    fetch(`https://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelID=${modeloId}`, options)
        .then(response => {
            response.json()
            .then(data => popularVersao(data))
        })
        .catch(e => console.log('Error: ' + e.message))
})

// Usado para tratar o Retorno da Api quando as Marcas são consultadas
const popularMarca = (marcas) => {
    for (var i = 0; i < marcas.length; i++) {
        var opt = document.createElement("option");
        opt.value = marcas[i].ID;
        opt.innerHTML = marcas[i].Name;
        if (marca.length <= marcas.length)
            marca.appendChild(opt);
    }
}

// Usado para tratar o Retorno da Api quando os Modelos são consultadas
const popularModelo = (modelos) => {
    modelo.options.length = 0;
    versao.options.length = 0;
    var fisrtOption = document.createElement("option");
    var versionOption = document.createElement("option");
    fisrtOption.value = 0;
    versionOption.value = 0;
    fisrtOption.innerHTML = "Selecione o Modelo";
    versionOption.innerHTML = "Selecione a Versao";
    versao.appendChild(versionOption);
    modelo.appendChild(fisrtOption);
    for (var i = 0; i < modelos.length; i++) {
        var opt = document.createElement("option");
        opt.value = modelos[i].ID;
        opt.innerHTML = modelos[i].Name;
        if (modelo.length <= modelos.length) {
            modelo.appendChild(opt);
        }
    }
}

// Usado para tratar o Retorno da Api quando os Modelos são consultadas
const popularVersao = (modelos) => {
    versao.options.length = 0;
    var fisrtOption = document.createElement("option");
    fisrtOption.value = 0;
    fisrtOption.innerHTML = "Selecione a Versao";
    versao.appendChild(fisrtOption);
    for (var i = 0; i < modelos.length; i++) {
        var opt = document.createElement("option");
        opt.value = modelos[i].ID;
        opt.innerHTML = modelos[i].Name;
        if (versao.length <= modelos.length) {
            versao.appendChild(opt);
        }
    }
}

const popularAnuncios = (anuncios) => {
    var div = document.createElement("div");
    var img = document.createElement("img");
    var color = document.createElement("label");
    var ID = document.createElement("label");
    var KM = document.createElement("label");
    var make = document.createElement("label");
    var model = document.createElement("label");
    var price = document.createElement("label");
    var version = document.createElement("label");
    var yearFab = document.createElement("label");
    var yearModel = document.createElement("label");
    

    for (var i = 0; i < anuncios.length; i++) {
        img.src = anuncios[i].Image;
        ID.innerHTML = "ID: " + anuncios[i].ID;
        color.innerHTML ="Cor: " + anuncios[i].Color;
        KM.innerHTML ="Quilometragem: " + anuncios[i].KM;
        make.innerHTML = "Marca: " + anuncios[i].Make;
        model.innerHTML = "Modelo: " + anuncios[i].Model;
        price.innerHTML = "Preço: R$ " + anuncios[i].Price;
        version.innerHTML = "Versão: " + anuncios[i].Version;
        yearFab.innerHTML = "Ano Fabricação: " + anuncios[i].YearFab;
        yearModel.innerHTML = "Ano Modelo: " + anuncios[i].YearModel;
        
        div.appendChild(ID);
        div.appendChild(color);
        div.appendChild(KM);
        div.appendChild(make);
        div.appendChild(model);
        div.appendChild(price);
        div.appendChild(version);
        div.appendChild(yearFab);
        div.appendChild(yearModel);
        div.appendChild(img);

        areaAnuncios.appendChild(div);
        document.body.append(areaAnuncios);
        div = document.createElement("div");

    }
    
    
}

function InserirAnuncio() {
    let anuncio = {
        Make: marca.selectedOptions[0].innerText, Model: modelo.selectedOptions[0].innerText,
        Version: versao.selectedOptions[0].innerText, YearModel: ano.value,
        KM: km.value, Obs: obs.value
    };
    fetch('InserirAnuncio', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(anuncio)
    }).then(response => {
        return response.json();
    }).then(jsonResponse => {
        console.log(jsonResponse);
    }).catch(error => {
        console.log(error)
    })
}

function EditarAnuncio(id) {
    let anuncio = {
        ID: id, Make: marca.selectedOptions[0].innerText, Model: modelo.selectedOptions[0].innerText,
        Version: versao.selectedOptions[0].innerText, YearModel: ano.value,
        KM: km.value, Obs: obs.value
    };
    fetch('EditarAnuncio', {
        method: 'Post',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(anuncio)
    }).then(response => {
        return response.json();
    }).then(jsonResponse => {
        console.log(jsonResponse);
    }).catch(error => {
        console.log(error)
    })
}

function RemoverAnuncio(id) {
    let anuncio = {
        ID: id
    };
    fetch('RemoverAnuncio', {
        method: 'Post',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(anuncio)
    }).then(response => {
        return response.json();
    }).then(jsonResponse => {
        console.log(jsonResponse);
    }).catch(error => {
        console.log(error)
    })
}
