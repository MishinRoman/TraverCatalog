import React from 'react';
import {
  MdOutlineArrowBackIos,
  MdOutlineArrowForwardIos,
} from "react-icons/md";




type PaginationProps = {
  onNextPageClick: () => void;
  onPrevPageClick: () => void;
  disable: {
    left: boolean;
    right: boolean;
  };
  nav?: {
    current: number;
    total: number;
  };
};

const Pagination = (props: PaginationProps) => {
  const { nav = null, disable, onNextPageClick, onPrevPageClick } = props;

  const handleNextPageClick = () => {
    onNextPageClick();
  };
  const handlePrevPageClick = () => {
    onPrevPageClick();
  };

  return (
    <div className="flex flex-1 justify-between h-7 ">
      <button
        className="relative inline-flex items-center rounded-md border dark:border-gray-800 border-gray-300 dark:bg-slate-400 bg-white px-4 py-2 text-sm font-medium text-gray-700 hover:bg-gray-50"
        type="button"
        onClick={handlePrevPageClick}
        disabled={disable.left}
      >
        <MdOutlineArrowBackIos/>
        <p>Назад</p>
        
      </button>
      {nav && (
        <div>
        <p className="text-sm dark:text-white text-gray-700">
        <span className="font-medium"> Страница {nav.current} из {nav.total} </span>
        </p>
      </div>
       
      )}
      <button
        className="relative inline-flex items-center rounded-md border dark:border-gray-800 border-gray-300 dark:bg-slate-400 bg-white px-4 py-2 text-sm font-medium text-gray-700 hover:bg-gray-50"
        type="button"
        onClick={handleNextPageClick}
        disabled={disable.right}
      >
        <p className={"buttom-1"}>Вперед</p>
        < MdOutlineArrowForwardIos />
      </button>
    </div>
  );
};

export default Pagination;