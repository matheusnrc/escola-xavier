import React, { useEffect, useState } from "react";
import api from "../services/api";
import { Container } from "../UI/GlobalStyle";

import editar from "../assets/img/editar.svg";
import deletar from "../assets/img/deletar-usuario.svg";
import {
  Box,
  CabecalhoLista,
  DivFlexOne,
  ImgLista,
  ItemLista,
  Titulo,
  TituloLista,
  Input,
  Formulario,
  Botao,
} from "../assets/img/components/commonStyle";

const Aluno = () => {
  const [nomeAluno, setNomeAluno] = useState("");
  const [listaDeAlunos, setListaDeAlunos] = useState([]);

  const [idAlunoEdicao, setIdEdicao] = useState(0);

  useEffect(async () => {
    await buscarAlunos();
  }, []);

  async function cadastrarAluno(evento) {
    evento.preventDefault();
    evento.stopPropagation();

    if (validarAluno()) {
      let retorno = null;
      if (idAlunoEdicao == 0)
        retorno = await api.post("Aluno/Cadastrar", { nomeAluno });
      else {
        retorno = await api.put("Aluno/Editar", {
          id: idAlunoEdicao,
          nomeAluno,
        });
        setIdEdicao(0);
      }

      alert(retorno.data.dados);
      setNomeAluno("");
      await buscarAlunos();
    }
  }

  function validarAluno() {
    if (nomeAluno == "") {
      alert("Informe o nome do aluno");
      return false;
    }

    return true;
  }

  async function buscarAlunos() {
    let alunos = await api.get("Aluno/ObterTodos");
    setListaDeAlunos(alunos.data.dados);
  }

  async function deletarAluno(id) {
    let deletar = await api.delete(`Aluno/Excluir?id=${id}`);
    alert(deletar.data.dados);
    await buscarAlunos();
  }

  function preencherEdicao(id, nomeAluno) {
    setNomeAluno(nomeAluno);
    setIdEdicao(id);
  }

  return (
    <main>
      <Container>
        <Box>
          <Titulo>{idAlunoEdicao == 0 ? "Cadastro de" : "Editar"} Aluno</Titulo>
          <Formulario onSubmit={cadastrarAluno}>
            <Input
              placeholder={"Informe o nome do aluno..."}
              onChange={(text) => setNomeAluno(text.target.value)}
              value={nomeAluno}
            />
            <Botao>{idAlunoEdicao == 0 ? "Cadastrar" : "Editar"} Aluno</Botao>
          </Formulario>
          {listaDeAlunos && (
            <>
              <TituloLista>Lista de Alunos</TituloLista>
              <CabecalhoLista>
                <DivFlexOne>
                  <h3>Cod. Aluno</h3>
                </DivFlexOne>
                <DivFlexOne>
                  <h3>Nome Aluno</h3>
                </DivFlexOne>
                <DivFlexOne>
                  <h3>Editar</h3>
                </DivFlexOne>
                <DivFlexOne>
                  <h3>Deletar</h3>
                </DivFlexOne>
              </CabecalhoLista>

              {listaDeAlunos &&
                listaDeAlunos.map((aluno, index) => {
                  return (
                    <ItemLista key={index}>
                      <DivFlexOne>{aluno.id}</DivFlexOne>
                      <DivFlexOne>{aluno.nomeAluno}</DivFlexOne>
                      <DivFlexOne>
                        <ImgLista
                          src={editar}
                          onClick={() =>
                            preencherEdicao(aluno.id, aluno.nomeAluno)
                          }
                          alt="Editar"
                        />
                      </DivFlexOne>
                      <DivFlexOne>
                        <ImgLista
                          src={deletar}
                          onClick={() => deletarAluno(aluno.id)}
                          alt="Deletar"
                        />
                      </DivFlexOne>
                    </ItemLista>
                  );
                })}
            </>
          )}
        </Box>
      </Container>
    </main>
  );
};

export default Aluno;
