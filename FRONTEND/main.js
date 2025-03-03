async function submit() {
  const talajTipus = document.querySelector('#talaj-tipus').value;
  const meres1 = document.querySelector('#meres-1').value;
  const meres2 = document.querySelector('#meres-2').value;


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