import React, { useState } from "react";
import { IMedia } from "../interfaces/app.interfaces";
import {
  MdOutlineArrowBackIos,
  MdOutlineArrowForwardIos,
} from "react-icons/md";

type Props = {
  images: IMedia[];
};
const cardWidth = 900;

const GalereyList = ({ images }: Props) => {
  const [count, setCount] = useState(0);
  const [path, setPath] = useState(images[0]?.physicalPath + images[0]?.name);

  return (
    <div>
      <div className={"flex flex-row justify-between"}>
        <button
          onClick={() =>
            count != 0 ? setCount(count - 1) : setCount(images.length - 1)
          }
          title="back"
        >
          <MdOutlineArrowBackIos size={36} className={"text-black dark:text-white "}/>
        </button>
        <img
          src={images[count]?.physicalPath + images[count]?.name}
          title={images[count]?.name}
          width={cardWidth - 4}
          height={cardWidth}
        />

        <button
          onClick={() =>
            count < images.length - 1 ? setCount(count + 1) : setCount(0)
          }
          title="forward"
        >
          <MdOutlineArrowForwardIos size={36} className={"text-black dark:text-white "} />
        </button>
      </div>
      
    </div>
  );
};

export default GalereyList;
