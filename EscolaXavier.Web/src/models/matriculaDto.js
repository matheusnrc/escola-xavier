export class MatriculaDto {
    id;
    nomeAluno;
    nomeMateria;
    nota;
  
    constructor(id, nomeAluno, nomeMateria, nota) {
      this.id = id;
      this.nomeAluno = nomeAluno;
      this.nomeMateria = nomeMateria;
      this.nota = nota;
    }
  }