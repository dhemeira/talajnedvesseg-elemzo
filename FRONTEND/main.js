async function submit() {
  let talajTipus = document.querySelector('#talaj-tipus').value;
  let meres1 = document.querySelector('#meres-1').value;
  let meres2 = document.querySelector('#meres-2').value;

  talajTipus = csvToArray(talajTipus)
  meres1 = csvToArray(meres1)
  meres2 = csvToArray(meres2)

  fetch('http://localhost:5160/talajnedvesseg', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json', },
    body: JSON.stringify({
      matrixa: talajTipus,
      matrixb: meres1,
      matrixc: meres2,
    })
  })
    .then(async resp => {
      console.log('Response: ', resp)
      if (resp.status === 200) {
        const data = await resp.json()
        displayResult(data)
      }
    })
    .catch(error => console.log(error))
}

function displayResult(data) {
  console.log(data)
}

function csvToArray(str) {
  return str.split('\n').map(row => row.trim().split(','));
}

function fillWithTestData() {
  document.querySelector('#talaj-tipus').value = `  Sós,Tőzeges,Lúgos,Vályogos,Szerves
  Vályogos,Savanyú,Vályogos,Sós,Homokos
  Agyagos,Agyagos,Tőzeges,Lúgos,Lúgos
  Tőzeges,Szerves,Szerves,Savanyú,Tőzeges
  Savanyú,Lúgos,Homokos,Szerves,Agyagos
  Lúgos,Sós,Sós,Tőzeges,Sós
  Szerves,Vályogos,Savanyú,Homokos,Vályogos
  Homokos,Homokos,Agyagos,Agyagos,Savanyú`;
  document.querySelector('#meres-1').value = `  0.616555682,0.640437434,0.394921648,0.989150841,0.094593963
  0.73640787,0.533786646,0.010040263,0.103582895,0.822426946
  0.482072405,0.307524409,0.554290788,0.34809631,0.050875698
  0.030366978,0.029007159,0.684912003,0.15174959,0.169129819
  0.801127784,0.378496264,0.028311732,0.819583358,0.258000695`;
  document.querySelector('#meres-2').value = `  326.8790814,142.532508,451.0244456,492.2147514,9.854457502
  196.8179513,254.0216116,135.4596622,871.5870911,885.1868424
  552.9238429,388.6590505,877.9482358,693.8786444,255.2241038
  927.5234866,358.335735,359.6940165,240.604347,508.8106815
  611.5528772,937.5820018,131.415368,40.17513664,401.7750407`;
}