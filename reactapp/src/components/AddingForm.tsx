import React, { ChangeEvent, FormEvent, useState } from "react";
import { ITraveForCreate, ITravel } from "../interfaces/app.interfaces";
import { DefaultValue } from "../services/travel.defaultValue";
import InputTravel from "./InputTravel";
import travelsService from "../services/travels.service";
type Props = { travel?: ITravel };

const AddingForm = (props: Props) => {
  const [travel, setTraver] = useState<ITravel>(props.travel ?? DefaultValue);

  const ohChangeHandle = (value) => {
    setTraver(value);
  };

  function onSubmitHandle(event: FormEvent<HTMLFormElement>): void {
    event.preventDefault();
    console.log(travel.media);
    travelsService.AddTravel(travel);
  }

  return (
    <form onSubmit={onSubmitHandle} className={"rounded-lg"}>
      <InputTravel onChange={ohChangeHandle} travel={travel} />
      <button className={"bg-blue-400 p-2 rounded-xl"} type="submit">
        Сохранить
      </button>
    </form>
  );
};

export default AddingForm;
