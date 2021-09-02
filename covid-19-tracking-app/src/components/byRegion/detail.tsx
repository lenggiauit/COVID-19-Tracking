import React from 'react';
import { Covid19DataByRegion } from '../../types/covid19DataByRegion';
import * as bt from 'react-bootstrap';
import Placeholder from 'react-bootstrap/Placeholder';
import { GetRandomBgColor } from '../../utils/functions';
import "./regionItem.css";
import { Translation } from '../translation';
import { Doughnut } from 'react-chartjs-2';
import { RegionColors } from '../../types/colors';

type Props = {
    selectedItemData?: Covid19DataByRegion;
}

const RegionDetail: React.FC<Props> = ({ selectedItemData }) => {

    return (
        <>
            {selectedItemData?.regionCode}
        </>
    )
}

export default RegionDetail;