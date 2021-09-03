import React from 'react';
import { Placeholder } from 'react-bootstrap';
import { GetRandomBgColor } from '../../utils/functions';
import { uuid } from 'uuidv4';

type Props = {
    lineCount?: number;
}
const DetailLoading: React.FC<Props> = ({ lineCount }) => {
    return (
        <>{
            Array.from(Array(lineCount != null ? lineCount : 1).keys()).map((i) => (
                <Placeholder key={uuid()} as="p" animation="glow">
                    <Placeholder key={uuid()} xs={12} bg={GetRandomBgColor()} size="xs" />
                </Placeholder>
            ))
        }
        </>
    )
}

export default DetailLoading;