import React, { ChangeEvent, useState } from "react";
import { IMedia, ITravel } from "../interfaces/app.interfaces";
import { DefaultValue } from "../services/travel.defaultValue";

type Props = {
  travel: ITravel;
  onChange: (propertyValue) => any;
};

const InputTravel = (props: Props) => {
  const [travel, setTravel] = useState(props.travel);
  const labes = new Map<string, string>([
    ["id", "Ид"],
    ["description", "Описание"],
    ["startDate", "Дата начала поездки"],
    ["endDate", "Дата окончания поездки"],
    ["media", "Фотографии"],
    ["users", "Пользователи"],
    ["comments", "Комментарии"],
    ["price", "Цена"],
  ]);
  const propartyNames: string[] = Object.getOwnPropertyNames(
    props.travel ?? DefaultValue
  );

  const typeInput = {
    id: "number",
    descripion: "textaria",
    startDate: "datetime-local",
    endDate: "datetime-local",
    media: "file",
    comments: "text",
    price: "finance",
  };

  const handleFilesChange = (event: ChangeEvent<HTMLInputElement>) => {
    const files: File[] = event.target.files
      ? Array.from(event.target.files)
      : [];
    // setTravel({...props.travel, media: {...files}})
  };

  props.onChange(travel);
  return propartyNames.map((i) => (
    <div className=" bg-slate-400 p-1 w-auto m-auto text-end rounded-sm">
      <label htmlFor={i + "Input"}>{labes.get(i) ?? i}</label>
      <input
        id={i + "Input"}
        type={typeInput[i]}
        disabled={i === "id"}
        className="outline outline-2 outline-offset-2 rounded-sm m-4 text-gray-900"
        onChange={(e) => {
          // (travel[i]==="media")?handleFilesChange(e):
          setTravel({ ...props.travel, [i]: e.target.value });
        }}
      />
    </div>
  ));
};

export default InputTravel;
